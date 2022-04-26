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

        [SerializeField, Tooltip("Скорость вращения камеры")]
        private float _speedRotate = 20f;

        private void Awake()
        {
            controls = new PlayerControls();
            CoroutineMovement = StartCoroutine(Movement());
            _cameraTransform = this.GetComponentInChildren<Camera>().transform;
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
            if (Mouse.current.rightButton.isPressed)
            {
                //Debug.Log("правая кнопка мыши нажата и удерживается");
                var delta = controls.ActionMap.RotateCamera.ReadValue<Vector2>();
                var angle = new Vector3(-delta.y, delta.x, 0f) * _speedRotate * Time.deltaTime;
                //Вращаем камеру
                UpdateRotateWithCorrection(transform.rotation * Quaternion.Euler(angle));
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }       
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        //Обновляет поворот камеры без уклона по оси OZ
        private void UpdateRotateWithCorrection(in Quaternion rotate)
        {
            transform.localRotation = rotate;

            var corrective = transform.eulerAngles;
            corrective.z = 0f;
            transform.eulerAngles = corrective;
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
