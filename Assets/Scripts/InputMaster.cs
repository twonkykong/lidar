//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/InputMaster.inputactions
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

public partial class @InputMaster : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""d9d65a49-9905-4f3b-af18-58af4da8a140"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""936bb65d-71df-45da-8eb1-15871896d29d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LookX"",
                    ""type"": ""Value"",
                    ""id"": ""5479bb0e-259f-46c6-8f1d-5abd29450110"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LookY"",
                    ""type"": ""Value"",
                    ""id"": ""f03efbf3-df8a-44b6-a73a-54b087f94554"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Use gun"",
                    ""type"": ""Button"",
                    ""id"": ""a13b4f94-8456-4e18-9419-b624c7fa2163"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1.401298E-45,behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Change mode"",
                    ""type"": ""Button"",
                    ""id"": ""7f097a1c-4c3e-46fe-8e51-30a1947005ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Change radius"",
                    ""type"": ""Value"",
                    ""id"": ""15133ba3-62d0-4f26-a378-944a53744a1a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e32bb890-2c5a-4118-9f74-8bc839a818fb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3ef4e543-0f3e-46c0-b305-54658c2d8f55"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b05a12b8-4ca8-4f5f-964f-85859f4008f0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38dc02da-7ae6-4f76-9133-505279ecd194"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fb6ba3ee-378b-4479-ac08-f0d55dc5980a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6f5bf6d0-1e13-4e55-9e29-18dbe855ad6e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use gun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e862572-9d7a-4601-8985-8a2997f608fd"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change radius"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3a4ba52-7545-4635-b7b1-1239416fa3d0"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1418770-1ef6-45c3-8796-16e7e8f4b389"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32097dc8-a9f6-402b-b1b0-ef5e8cce8e1d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""a9bc6512-7a2c-4750-857c-eaaadcb2a9c6"",
            ""actions"": [
                {
                    ""name"": ""Any key"",
                    ""type"": ""Button"",
                    ""id"": ""3ef56782-d60c-4d90-9b19-90a527f1a210"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8864c9ef-1081-4970-a6ff-cc9ef487f860"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Any key"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d3244cb-4e76-4760-bf62-e5d9d43addb7"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Any key"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6044370f-ad15-45da-92b8-cb5d8eceb323"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Any key"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_Movement = m_Inputs.FindAction("Movement", throwIfNotFound: true);
        m_Inputs_LookX = m_Inputs.FindAction("LookX", throwIfNotFound: true);
        m_Inputs_LookY = m_Inputs.FindAction("LookY", throwIfNotFound: true);
        m_Inputs_Usegun = m_Inputs.FindAction("Use gun", throwIfNotFound: true);
        m_Inputs_Changemode = m_Inputs.FindAction("Change mode", throwIfNotFound: true);
        m_Inputs_Changeradius = m_Inputs.FindAction("Change radius", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Anykey = m_UI.FindAction("Any key", throwIfNotFound: true);
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

    // Inputs
    private readonly InputActionMap m_Inputs;
    private IInputsActions m_InputsActionsCallbackInterface;
    private readonly InputAction m_Inputs_Movement;
    private readonly InputAction m_Inputs_LookX;
    private readonly InputAction m_Inputs_LookY;
    private readonly InputAction m_Inputs_Usegun;
    private readonly InputAction m_Inputs_Changemode;
    private readonly InputAction m_Inputs_Changeradius;
    public struct InputsActions
    {
        private @InputMaster m_Wrapper;
        public InputsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Inputs_Movement;
        public InputAction @LookX => m_Wrapper.m_Inputs_LookX;
        public InputAction @LookY => m_Wrapper.m_Inputs_LookY;
        public InputAction @Usegun => m_Wrapper.m_Inputs_Usegun;
        public InputAction @Changemode => m_Wrapper.m_Inputs_Changemode;
        public InputAction @Changeradius => m_Wrapper.m_Inputs_Changeradius;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void SetCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnMovement;
                @LookX.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnLookX;
                @LookX.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnLookX;
                @LookX.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnLookX;
                @LookY.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnLookY;
                @LookY.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnLookY;
                @LookY.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnLookY;
                @Usegun.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnUsegun;
                @Usegun.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnUsegun;
                @Usegun.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnUsegun;
                @Changemode.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnChangemode;
                @Changemode.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnChangemode;
                @Changemode.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnChangemode;
                @Changeradius.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnChangeradius;
                @Changeradius.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnChangeradius;
                @Changeradius.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnChangeradius;
            }
            m_Wrapper.m_InputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @LookX.started += instance.OnLookX;
                @LookX.performed += instance.OnLookX;
                @LookX.canceled += instance.OnLookX;
                @LookY.started += instance.OnLookY;
                @LookY.performed += instance.OnLookY;
                @LookY.canceled += instance.OnLookY;
                @Usegun.started += instance.OnUsegun;
                @Usegun.performed += instance.OnUsegun;
                @Usegun.canceled += instance.OnUsegun;
                @Changemode.started += instance.OnChangemode;
                @Changemode.performed += instance.OnChangemode;
                @Changemode.canceled += instance.OnChangemode;
                @Changeradius.started += instance.OnChangeradius;
                @Changeradius.performed += instance.OnChangeradius;
                @Changeradius.canceled += instance.OnChangeradius;
            }
        }
    }
    public InputsActions @Inputs => new InputsActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Anykey;
    public struct UIActions
    {
        private @InputMaster m_Wrapper;
        public UIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Anykey => m_Wrapper.m_UI_Anykey;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Anykey.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAnykey;
                @Anykey.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAnykey;
                @Anykey.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAnykey;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Anykey.started += instance.OnAnykey;
                @Anykey.performed += instance.OnAnykey;
                @Anykey.canceled += instance.OnAnykey;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IInputsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLookX(InputAction.CallbackContext context);
        void OnLookY(InputAction.CallbackContext context);
        void OnUsegun(InputAction.CallbackContext context);
        void OnChangemode(InputAction.CallbackContext context);
        void OnChangeradius(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnAnykey(InputAction.CallbackContext context);
    }
}
