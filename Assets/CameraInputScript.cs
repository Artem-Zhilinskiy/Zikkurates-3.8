using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Zikkurat
{
    public class CameraInputScript : MonoBehaviour
    {
        public PlayerControls controls;
        Coroutine CoroutineMovement;
        private Transform _cameraTransform;

        private void Awake()
        {
            controls = new PlayerControls();
            CoroutineMovement = StartCoroutine(Movement());
            _cameraTransform = this.GetComponentInChildren<Camera>().transform;
        }

        private void OnEnable()
        {
            controls.ActionMap.Enable();
            controls.ActionMap.RotateCamera.performed += RotateCamera();
        }

        private void OnDisable()
        {
            controls.ActionMap.Disable();
            controls.ActionMap.RotateCamera.performed -= RotateCamera();
        }

        private IEnumerator Movement()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                var value = controls.ActionMap.CameraMovement.ReadValue<Vector2>();
                Vector3 direction = new Vector3(value.x/5, 0, value.y/5);
                transform.position += direction;
            }
        }
    }
}
