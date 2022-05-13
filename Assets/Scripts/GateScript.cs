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

        private void Awake()
        {
            controls = new PlayerControls();
        }
        
        //Оказывается, это событие клика не по воротам, а вообще.
        /*
        private void OnEnable()
        {
            controls.ActionMap.Enable();
            controls.ActionMap.GateClick.performed += OnClick;
        }

        private void OnDisable()
        {
            controls.ActionMap.GateClick.performed -= OnClick;
            controls.ActionMap.Disable();
        }

        private void OnClick(CallbackContext context)
        {
                if (ClickGateEvent != null)
                {
                    ClickGateEvent(this.gameObject.name);
                }
                else
                {
                    Debug.Log("ClickGateEvent = null");
                }
        }
        */

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            //Тут этот скрипт будет обращаться к UnitManager методам по выдвижению панели.
        }
    }
}