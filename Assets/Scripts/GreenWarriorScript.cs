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
            _gameManager = GameObject.Find("GameManager");
            _gameManager.GetComponent<UnitManager>().SetVelocity(this.gameObject);
        }
    }
}