using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Zikkurat
{
    public class GateScript : MonoBehaviour, IPointerClickHandler
    {
        public delegate void ClickGateDelegate(string _gateName);
        /// <summary>
        /// Событие клика на игровом объекте
        /// </summary>
        public event ClickGateDelegate ClickGateEvent;

        public PlayerControls controls;
        [SerializeField]
        private GameObject GameManager;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            //Тут этот скрипт будет обращаться к UnitManager методам по выдвижению панели.
            GameManager.GetComponent<UnitManager>().OpenPanel(this.gameObject.name);
        }
    }
}