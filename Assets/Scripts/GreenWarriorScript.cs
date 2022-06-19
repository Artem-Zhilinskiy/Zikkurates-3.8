using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class GreenWarriorScript : MonoBehaviour
    {

        Vector3 _destination = new Vector3(0,2f,0);
        private GameObject _gameManager;
        private GameObject _alertSphere;
        private GameObject _enemy;

        private bool _inBattle = false;
        private void Awake()
        {
            _alertSphere = GameObject.Find("AlertSphere");
            //Развернуть бойца в центр карты

            /*
            _gameManager = GameObject.Find("GameManager");
            _gameManager.GetComponent<UnitManager>().SetVelocity(this.gameObject);
            this.gameObject.GetComponent<UnitEnvironment>().Moving(1f);
            */
        }

        /*
        Arrival(GameObject _target)
        {
        //Вычислить distance между this.gameObject и _target
        //Если _distance <1
        остановить движение
        если target == враг
        ударить();
        }

        Поиск врага()
        {
        }

        Удар()
        {
        Вероятность ударов - сильный и слабый + анимация
        }
        */

        private void Update()
        {
            //_gameManager.GetComponent<UnitManager>().SetVelocity(this.gameObject);
            Arrival(_destination);
            Alert();
        }

        private void Arrival(Vector3 _destination)
        {
            this.gameObject.transform.LookAt(_destination);
            float _distance = Vector3.Distance(this.transform.position, _destination);
            if (_distance < 2f)
            {
                this.gameObject.GetComponent<UnitEnvironment>().Moving(0f);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                if (_inBattle)
                {
                    //Анмация удара
                    this.gameObject.GetComponent<UnitEnvironment>().StartAnimation("FastAttack");
                }
            }
            else
            {
                this.gameObject.GetComponent<UnitEnvironment>().Moving(1f);
                this.GetComponent<Rigidbody>().velocity = this.transform.forward*5f;
            }
        }

        //Переход в режим боя, если только уже не в бою
        private void Alert()
        {
            //1. Вытащить из дочернего скрипта gameObject вошедшего воина
            if (_alertSphere.GetComponent<AlertSphereScript>()._enemy != null)
            {
                _enemy = _alertSphere.GetComponent<AlertSphereScript>()._enemy;
                string _name = _enemy.gameObject.name;
                Debug.Log(_name + " Alert");
                //2. Проверить, идёт ли бой (boolean) и если нет, то передать gameObject в Attack()
                if ((_name == "Fighter Blue(Clone)") || (_name == "Fighter Red(Clone)"))
                {
                    if (!_inBattle)
                    {
                        Attack(_enemy);
                    }
                }
            }
        }

        private void Attack(GameObject _enemy)
        {
            _inBattle = true;
            Arrival(_enemy.transform.position);
        }
    }
}