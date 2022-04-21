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

        private void Awake()
        {
            controls = new PlayerControls();
            CoroutineMovement = StartCoroutine(Movement());
        }

        private void OnEnable()
        {
            controls.ActionMap.Enable();
        }

        private void OnDisable()
        {
            controls.ActionMap.Disable();
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
