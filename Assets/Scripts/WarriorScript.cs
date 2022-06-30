using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class WarriorScript : MonoBehaviour
    {

        private Vector3 _destination = new Vector3(0, 2f, 0);
        private GameObject _gameManager;
        private GameObject _alertSphere = null;
        private GameObject _enemy = null;

        #region "Блок параметров юнита"
        //Здоровье
        private float _health;
        //Скорость перемещения
        private float _speed = 0f;
        //Урон от слабой атаки
        private float _fastDamage;
        //Урон от сильной атаки
        private float _strongDamage;
        //Вероятность промаха
        private float _missProbability;
        //Вероятность двукратного урона
        private float _critProbability;
        //Вероятность сильной атаки
        private float _strongAttackProbability;
        #endregion

        //Корутина удара
        Coroutine _fastAttack = null;

        private bool _inBattle = false;
        private void Awake()
        {
            //Важно! Вот это ищет первую AlertSphere
            //_alertSphere = GameObject.Find("AlertSphere");
            //А вот это ищет дочернюю AlertSphere
            _alertSphere = this.transform.Find("AlertSphere").gameObject;

            //Считывание и присвоение параметров из соответствующей панели
            SettingUnit();
        }

        private void Update()
        {
            Alert();
            Arrival(_destination);
        }

        private void Arrival(Vector3 _destination)
        {
            //Проверка на смещение врага
            if (_enemy != null)
            {
                _destination = _enemy.transform.position;
            }
            this.gameObject.transform.LookAt(_destination);
            float _distance = Vector3.Distance(this.transform.position, _destination);
            if (_distance < 2f)
            {
                if (_fastAttack == null)
                {
                    this.gameObject.GetComponent<UnitEnvironment>().Moving(0f);
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                if (_inBattle)
                {
                    //Отнять жизни у врага?
                    if (_fastAttack == null)
                    {
                        _fastAttack = StartCoroutine(FastAttackCoroutine());
                    }
                }
            }
            else
            {
                //Debug.Log("Двигаюсь к " + _destination);
                this.gameObject.GetComponent<UnitEnvironment>().Moving(1f);
                this.GetComponent<Rigidbody>().velocity = this.transform.forward * _speed;
            }
        }

        //Переход в режим боя, если только уже не в бою
        private void Alert()
        {
            //1. Вытащить из дочернего скрипта gameObject вошедшего воина
            if ((_enemy == null) && (_alertSphere.GetComponent<AlertSphereScript>()._enemy != null))
            {
                _enemy = _alertSphere.GetComponent<AlertSphereScript>()._enemy;
                string _name = _enemy.gameObject.name;
                //2. Проверить, идёт ли бой (boolean) и если нет, то передать gameObject в Attack()
                if ((_name != this.gameObject.name) && ((_name == "Fighter Blue(Clone)") || (_name == "Fighter Red(Clone)") || (_name == "Fighter Green(Clone)")))
                {
                    if (!_inBattle)
                    {
                        //Debug.Log("Начинаю атаку на " + _name + " на " + _enemy.transform.position);
                        Attack(_enemy);
                    }
                }
            }
        }

        private void Attack(GameObject _enemy)
        {
            _inBattle = true;
            _destination = _enemy.transform.position;
        }

        public void WoundFast()
        {
            _health -= _fastDamage;
            Debug.Log("У " + this.gameObject.name + " осталось " + _health + " здоровья");
            if (_health <= 0)
            {
                StopAllCoroutines();
                this.gameObject.GetComponent<UnitEnvironment>().StartAnimation("Die");
            }
        }

        private IEnumerator FastAttackCoroutine()
        {
            while (_inBattle)
            {
                yield return new WaitForSecondsRealtime(1f);
                //Анмация удара
                this.gameObject.GetComponent<UnitEnvironment>().StartAnimation("Fast");
                _enemy.GetComponent<WarriorScript>().WoundFast();
                if (_enemy == null)
                {
                    this.gameObject.GetComponent<UnitEnvironment>().Moving(0f);
                    _inBattle = false;
                    yield break;
                }
            }
        }

        //Считывание из панели и присвоение параметров юниту
        private void SettingUnit()
        {
            if (this.gameObject.name == "Fighter Green(Clone)")
            {
                _health = StaticParameter._healthGreen;
                _speed = StaticParameter._speedGreen;
                _fastDamage = StaticParameter._fastDamageGreen;
                _strongDamage = StaticParameter._strongDamageGreen;
                _missProbability = StaticParameter._missProbabilityGreen;
                _critProbability = StaticParameter._critProbabilityGreen;
                _strongAttackProbability = StaticParameter._strongAttackProbabilityGreen;
            }
            else if(this.gameObject.name == "Fighter Red(Clone)")
            {
                _health = StaticParameter._healthRed;
                _speed = StaticParameter._speedRed;
                _fastDamage = StaticParameter._fastDamageRed;
                _strongDamage = StaticParameter._strongDamageRed;
                _missProbability = StaticParameter._missProbabilityRed;
                _critProbability = StaticParameter._critProbabilityRed;
                _strongAttackProbability = StaticParameter._strongAttackProbabilityRed;
            }
            else if(this.gameObject.name == "Fighter Blue(Clone)")
            {
                _health = StaticParameter._healthBlue;
                _speed = StaticParameter._speedBlue;
                _fastDamage = StaticParameter._fastDamageBlue;
                _strongDamage = StaticParameter._strongDamageBlue;
                _missProbability = StaticParameter._missProbabilityBlue;
                _critProbability = StaticParameter._critProbabilityBlue;
                _strongAttackProbability = StaticParameter._strongAttackProbabilityBlue;
            }
        }
    }
}