using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class GreenWarriorScript : MonoBehaviour
    {
        private GameObject _gameManager; 
        private void Awake()
        {
            //Развернуть бойца в центр карты
            Vector3 _mapCenter = Vector3.zero;
            this.gameObject.transform.LookAt(_mapCenter);
            Arrival();
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
        }

        private void Arrival(Vector3 _destination)
        {

        }
    }
}