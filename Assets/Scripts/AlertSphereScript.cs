using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class AlertSphereScript : MonoBehaviour
    {
        public GameObject _enemy = null;
        private void OnTriggerEnter(Collider _collider)
        {
            //Проверка на враждебность
            //Если это Fighter любого цвета и имя вошедшего Fighter не совпадает с именем родительского gameObject, то атаковать, иначе ничего.
            //if (EnemyCheck(_collider.gameObject.name) && ((_enemy == null) && (_enemy.activeSelf != true)))
            if (EnemyCheck(_collider.gameObject.name)) 
            {
                _enemy = _collider.gameObject;
                //Debug.Log("враг - " + _collider.gameObject.name);
            }


        }
        private bool EnemyCheck(string _name)
        {
            if (((_name == "Fighter Green(Clone)") | (_name == "Fighter Red(Clone)") | (_name == "Fighter Blue(Clone)")) && (_name != transform.parent.name))
            {
                //Debug.Log("Enemy Check true");
                return true;
            }
            else
            {
                //Debug.Log("Enemy Check false");
                return false;
            }
        }
    }
}