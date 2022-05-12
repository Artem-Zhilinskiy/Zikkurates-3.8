using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Zikkurat
{
    public class GateScript : MonoBehaviour
    {
        public delegate void ClickGateDelegate();
        /// <summary>
        /// Событие клика на игровом объекте
        /// </summary>
        public event ClickGateDelegate ClickGateEvent;

        public PlayerControls controls;

        private void Awake()
        {
            controls = new PlayerControls();
        }

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
                    ClickGateEvent();
                }
                else
                {
                    Debug.Log("ClickGateEvent = null");
                }
        }

    }
}