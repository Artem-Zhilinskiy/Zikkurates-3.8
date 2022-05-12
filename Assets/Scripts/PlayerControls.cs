//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Zikkurat
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""ActionMap"",
            ""id"": ""71d8494b-f6ce-4210-8e92-249ba4d2f1e0"",
            ""actions"": [
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""d272fbb7-290b-4c5e-b27a-89da923d4119"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Value"",
                    ""id"": ""2f458f57-1e73-46c8-82a5-e26c2d793412"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""GateClick"",
                    ""type"": ""Button"",
                    ""id"": ""f0dbe86f-fde8-41e4-a5bb-8aca10711981"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2f9facd2-3fc6-4dc6-a0fc-ead1f52d5609"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""345ad2c4-dcb0-4b28-acbe-7bf62e04783c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""4bcb5a23-3d11-4172-a826-1ad07d703a40"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""de40dd48-126a-42d7-a287-54eaba95695d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""427b80a4-e10d-4901-84d0-f12cdf459427"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d8825a31-d42f-4f9d-963a-27347d7e9204"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fc9f592-55f9-4cac-b1d5-cec7e052c63a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GateClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // ActionMap
            m_ActionMap = asset.FindActionMap("ActionMap", throwIfNotFound: true);
            m_ActionMap_CameraMovement = m_ActionMap.FindAction("CameraMovement", throwIfNotFound: true);
            m_ActionMap_RotateCamera = m_ActionMap.FindAction("RotateCamera", throwIfNotFound: true);
            m_ActionMap_GateClick = m_ActionMap.FindAction("GateClick", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // ActionMap
        private readonly InputActionMap m_ActionMap;
        private IActionMapActions m_ActionMapActionsCallbackInterface;
        private readonly InputAction m_ActionMap_CameraMovement;
        private readonly InputAction m_ActionMap_RotateCamera;
        private readonly InputAction m_ActionMap_GateClick;
        public struct ActionMapActions
        {
            private @PlayerControls m_Wrapper;
            public ActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @CameraMovement => m_Wrapper.m_ActionMap_CameraMovement;
            public InputAction @RotateCamera => m_Wrapper.m_ActionMap_RotateCamera;
            public InputAction @GateClick => m_Wrapper.m_ActionMap_GateClick;
            public InputActionMap Get() { return m_Wrapper.m_ActionMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ActionMapActions set) { return set.Get(); }
            public void SetCallbacks(IActionMapActions instance)
            {
                if (m_Wrapper.m_ActionMapActionsCallbackInterface != null)
                {
                    @CameraMovement.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovement;
                    @CameraMovement.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovement;
                    @CameraMovement.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovement;
                    @RotateCamera.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnRotateCamera;
                    @RotateCamera.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnRotateCamera;
                    @RotateCamera.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnRotateCamera;
                    @GateClick.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnGateClick;
                    @GateClick.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnGateClick;
                    @GateClick.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnGateClick;
                }
                m_Wrapper.m_ActionMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @CameraMovement.started += instance.OnCameraMovement;
                    @CameraMovement.performed += instance.OnCameraMovement;
                    @CameraMovement.canceled += instance.OnCameraMovement;
                    @RotateCamera.started += instance.OnRotateCamera;
                    @RotateCamera.performed += instance.OnRotateCamera;
                    @RotateCamera.canceled += instance.OnRotateCamera;
                    @GateClick.started += instance.OnGateClick;
                    @GateClick.performed += instance.OnGateClick;
                    @GateClick.canceled += instance.OnGateClick;
                }
            }
        }
        public ActionMapActions @ActionMap => new ActionMapActions(this);
        public interface IActionMapActions
        {
            void OnCameraMovement(InputAction.CallbackContext context);
            void OnRotateCamera(InputAction.CallbackContext context);
            void OnGateClick(InputAction.CallbackContext context);
        }
    }
}
