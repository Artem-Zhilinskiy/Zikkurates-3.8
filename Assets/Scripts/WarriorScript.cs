using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class WarriorScript : MonoBehaviour
    {

        private Vector3 _destination = new Vector3(0,2f,0);
        private GameObject _gameManager;
        private GameObject _alertSphere = null;
        private GameObject _enemy = null;

        private int _health = 6;

        private bool _inBattle = false;
        private void Awake()
        {
            //Важно! Вот это ищет первую AlertSphere
            //_alertSphere = GameObject.Find("AlertSphere");
            //А вот это ищет дочернюю AlertSphere
            _alertSphere = this.transform.Find("AlertSphere").gameObject;
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
                this.gameObject.GetComponent<UnitEnvironment>().Moving(0f);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                if (_inBattle)
                {
                    //Анмация удара
                    this.gameObject.GetComponent<UnitEnvironment>().StartAnimation("Fast");
                    //Отнять жизни у врага?
                    _enemy.GetComponent<WarriorScript>().WoundFast();
                }
            }
            else
            {
                //Debug.Log("Двигаюсь к " + _destination);
                this.gameObject.GetComponent<UnitEnvironment>().Moving(1f);
                this.GetComponent<Rigidbody>().velocity = this.transform.forward*5f;
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
            _health -= 3;
            Debug.Log("У " + this.gameObject.name + " осталось " + _health + " здоровья");
            if (_health <=0)
            {
                this.gameObject.GetComponent<UnitEnvironment>().StartAnimation("Die");
            }
        }
    }
}