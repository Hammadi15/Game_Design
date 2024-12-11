//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Inputs/Pointer.inputactions
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

public partial class @Pointer: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Pointer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Pointer"",
    ""maps"": [
        {
            ""name"": ""PlayerPointer"",
            ""id"": ""8409d662-e16e-4b34-92dc-714d2e569154"",
            ""actions"": [
                {
                    ""name"": ""PointerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""68349ceb-93ab-465d-b547-2710e1cefdb9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2eb54c7e-ea0a-4814-b55a-3b21efca36f8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""82e1ba12-d037-4121-8b1a-ded5e145d293"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88539259-b904-49d0-99ea-d986a02e9cb8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""67de48e0-28f0-4cbc-9048-a6ff90a907f7"",
            ""actions"": [
                {
                    ""name"": ""Keyboard"",
                    ""type"": ""Value"",
                    ""id"": ""370083a1-ff35-4561-9b53-4d2c830a79d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""81444cee-67e1-4fba-9220-7b6009956276"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""519a6225-17ad-42df-8895-65c0d534b157"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b20a47f0-307f-4ad7-af15-a2e527cbdcd3"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerPointer
        m_PlayerPointer = asset.FindActionMap("PlayerPointer", throwIfNotFound: true);
        m_PlayerPointer_PointerPosition = m_PlayerPointer.FindAction("PointerPosition", throwIfNotFound: true);
        m_PlayerPointer_Attack = m_PlayerPointer.FindAction("Attack", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_Keyboard = m_Inventory.FindAction("Keyboard", throwIfNotFound: true);
    }

    ~@Pointer()
    {
        UnityEngine.Debug.Assert(!m_PlayerPointer.enabled, "This will cause a leak and performance issues, Pointer.PlayerPointer.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_Inventory.enabled, "This will cause a leak and performance issues, Pointer.Inventory.Disable() has not been called.");
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

    // PlayerPointer
    private readonly InputActionMap m_PlayerPointer;
    private List<IPlayerPointerActions> m_PlayerPointerActionsCallbackInterfaces = new List<IPlayerPointerActions>();
    private readonly InputAction m_PlayerPointer_PointerPosition;
    private readonly InputAction m_PlayerPointer_Attack;
    public struct PlayerPointerActions
    {
        private @Pointer m_Wrapper;
        public PlayerPointerActions(@Pointer wrapper) { m_Wrapper = wrapper; }
        public InputAction @PointerPosition => m_Wrapper.m_PlayerPointer_PointerPosition;
        public InputAction @Attack => m_Wrapper.m_PlayerPointer_Attack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerPointer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerPointerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerPointerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerPointerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerPointerActionsCallbackInterfaces.Add(instance);
            @PointerPosition.started += instance.OnPointerPosition;
            @PointerPosition.performed += instance.OnPointerPosition;
            @PointerPosition.canceled += instance.OnPointerPosition;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
        }

        private void UnregisterCallbacks(IPlayerPointerActions instance)
        {
            @PointerPosition.started -= instance.OnPointerPosition;
            @PointerPosition.performed -= instance.OnPointerPosition;
            @PointerPosition.canceled -= instance.OnPointerPosition;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
        }

        public void RemoveCallbacks(IPlayerPointerActions instance)
        {
            if (m_Wrapper.m_PlayerPointerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerPointerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerPointerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerPointerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerPointerActions @PlayerPointer => new PlayerPointerActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private List<IInventoryActions> m_InventoryActionsCallbackInterfaces = new List<IInventoryActions>();
    private readonly InputAction m_Inventory_Keyboard;
    public struct InventoryActions
    {
        private @Pointer m_Wrapper;
        public InventoryActions(@Pointer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Keyboard => m_Wrapper.m_Inventory_Keyboard;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void AddCallbacks(IInventoryActions instance)
        {
            if (instance == null || m_Wrapper.m_InventoryActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Add(instance);
            @Keyboard.started += instance.OnKeyboard;
            @Keyboard.performed += instance.OnKeyboard;
            @Keyboard.canceled += instance.OnKeyboard;
        }

        private void UnregisterCallbacks(IInventoryActions instance)
        {
            @Keyboard.started -= instance.OnKeyboard;
            @Keyboard.performed -= instance.OnKeyboard;
            @Keyboard.canceled -= instance.OnKeyboard;
        }

        public void RemoveCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInventoryActions instance)
        {
            foreach (var item in m_Wrapper.m_InventoryActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    public interface IPlayerPointerActions
    {
        void OnPointerPosition(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnKeyboard(InputAction.CallbackContext context);
    }
}