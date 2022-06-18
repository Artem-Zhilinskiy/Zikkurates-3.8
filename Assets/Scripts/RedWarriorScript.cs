using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class RedWarriorScript : MonoBehaviour
    {

        Vector3 _mapCenter = Vector3.zero;
        private GameObject _gameManager; 
        private void Awake()
        {
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
            Arrival(_mapCenter);
        }

        private void Arrival(Vector3 _destination)
        {
            this.gameObject.transform.LookAt(_mapCenter);
            float _distance = Vector3.Distance(this.transform.position, _destination);
            if (_distance < 1f)
            {
                this.gameObject.GetComponent<UnitEnvironment>().Moving(0f);
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                this.gameObject.GetComponent<UnitEnvironment>().Moving(1f);
                this.GetComponent<Rigidbody>().velocity = this.transform.forward*5f;
            }
        }
    }
}