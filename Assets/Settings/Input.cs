// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""8426ebae-66e5-4ba2-9c69-bfe86f899dff"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""94b0d569-4ce9-4d7f-8f9c-ed8c60325752"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""ed6eb40e-9de5-4ff9-b9c1-6db834966fa0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""13181caa-bdf3-4970-ba8f-3f9ce1674d34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""99f81f06-5c43-4ed1-91f6-312633a13af6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""89c2fdaa-1f91-4ed8-91a5-481eb0e60300"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Value"",
                    ""id"": ""2bc14333-7835-4108-a77b-12dee42b9e4b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal2"",
                    ""type"": ""Value"",
                    ""id"": ""4e924b05-cbb7-4fd8-acdc-1b07c72659af"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical2"",
                    ""type"": ""Value"",
                    ""id"": ""35abe987-e752-48c8-bc75-517c3ed44916"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3661544-91fb-49e5-a7da-fcb627365473"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7010ed1e-8eb1-4a23-b600-6ad8d0f7b70f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""247d1054-e928-4d1c-a757-675926e64215"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""699454ef-faa1-4b1c-aae7-f2364e2777eb"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0b6c7ac-324e-453a-ab09-5ff4fb5d7816"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""088b87d3-4016-4882-ade4-bbc29165e632"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8127d585-80a0-42bc-b378-dd11d22bd60a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fff43054-e76f-4cd5-a093-b29535064566"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38325def-0848-4938-ac90-8ca7f3c93484"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8ba89b7c-a50e-43de-be82-e438a3c821c7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""227e8463-08b3-430f-b256-6bcf61a70b52"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""52d4767c-3e96-47d2-9297-22bb000c8757"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""205aa693-ed9f-4b99-b113-8c39ba100c0d"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b397c39-93d6-4734-8840-14bc659955de"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8302fc90-8530-4463-919c-4c2c3d993a74"",
                    ""path"": ""<Gamepad>/dpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e9107189-1a32-4a31-bd42-4a7191322d60"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7283f99f-cc05-426a-9d93-b5fed55845e8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9603d1a2-dc52-4344-88cf-6c31a6a94060"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""fc3276f3-49d2-4154-b093-0b3b2dc235e7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal2"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""968782eb-1195-4920-89ab-852c2feadc32"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2ed4c7c8-7cd6-4603-b217-b2fe56cda012"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e30b30cf-b715-4832-bba4-f0e15cb6de81"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical2"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c123440b-a865-40c9-84b7-05a96d1b072a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fab47829-b7eb-4c7a-8b36-06a171c21cb2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_A = m_Game.FindAction("A", throwIfNotFound: true);
        m_Game_B = m_Game.FindAction("B", throwIfNotFound: true);
        m_Game_X = m_Game.FindAction("X", throwIfNotFound: true);
        m_Game_Y = m_Game.FindAction("Y", throwIfNotFound: true);
        m_Game_Horizontal = m_Game.FindAction("Horizontal", throwIfNotFound: true);
        m_Game_Vertical = m_Game.FindAction("Vertical", throwIfNotFound: true);
        m_Game_Horizontal2 = m_Game.FindAction("Horizontal2", throwIfNotFound: true);
        m_Game_Vertical2 = m_Game.FindAction("Vertical2", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_A;
    private readonly InputAction m_Game_B;
    private readonly InputAction m_Game_X;
    private readonly InputAction m_Game_Y;
    private readonly InputAction m_Game_Horizontal;
    private readonly InputAction m_Game_Vertical;
    private readonly InputAction m_Game_Horizontal2;
    private readonly InputAction m_Game_Vertical2;
    public struct GameActions
    {
        private @Input m_Wrapper;
        public GameActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_Game_A;
        public InputAction @B => m_Wrapper.m_Game_B;
        public InputAction @X => m_Wrapper.m_Game_X;
        public InputAction @Y => m_Wrapper.m_Game_Y;
        public InputAction @Horizontal => m_Wrapper.m_Game_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_Game_Vertical;
        public InputAction @Horizontal2 => m_Wrapper.m_Game_Horizontal2;
        public InputAction @Vertical2 => m_Wrapper.m_Game_Vertical2;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_GameActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnA;
                @B.started -= m_Wrapper.m_GameActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnB;
                @X.started -= m_Wrapper.m_GameActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnX;
                @Y.started -= m_Wrapper.m_GameActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnY;
                @Horizontal.started -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical;
                @Horizontal2.started -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal2;
                @Horizontal2.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal2;
                @Horizontal2.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnHorizontal2;
                @Vertical2.started -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical2;
                @Vertical2.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical2;
                @Vertical2.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnVertical2;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Horizontal2.started += instance.OnHorizontal2;
                @Horizontal2.performed += instance.OnHorizontal2;
                @Horizontal2.canceled += instance.OnHorizontal2;
                @Vertical2.started += instance.OnVertical2;
                @Vertical2.performed += instance.OnVertical2;
                @Vertical2.canceled += instance.OnVertical2;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnHorizontal2(InputAction.CallbackContext context);
        void OnVertical2(InputAction.CallbackContext context);
    }
}
