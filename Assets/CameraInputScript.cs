using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Zikkurat
{
    public class CameraInputScript : MonoBehaviour
    {
        public PlayerControls controls;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.ActionMap.Enable();
        }

        private void OnDisable()
        {
            controls.ActionMap.Disable();
        }
        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var value = controls.ActionMap.CameraMovement.ReadValue<Vector2>();
            Vector3 direction = new Vector3(value.x,0 , value.y);
            GetComponent<Rigidbody>().AddForce(direction, ForceMode.Force);
        }
    }
}
