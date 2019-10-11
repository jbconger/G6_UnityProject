// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/Controls/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""d3f7c1da-3f33-41d8-a77b-a4c3a544e3ad"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""003121ea-0373-4869-8ac1-6df38ccdb39f"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""8d58a106-63d9-494e-a5db-f65faa0d9f30"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""a87dc691-ad20-40bd-94ba-e079f7e364f5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DodgeRoll"",
                    ""type"": ""Button"",
                    ""id"": ""0a9f35d4-771a-4a0c-b3d8-d5af11f64248"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NotchArrow"",
                    ""type"": ""Button"",
                    ""id"": ""70e85cec-36c4-4d5c-9123-1c90a4c8fa13"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PullArrow"",
                    ""type"": ""Button"",
                    ""id"": ""27eb8b1d-4e4c-4b7f-9fdc-4960d972f6d5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d552ef19-a4c5-4f2a-b457-0bae72120ac9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83adc26e-7651-4619-bf1a-1ad6e2541464"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43efffe3-d2bd-4081-86c2-228a0384bdd0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press(pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7420c1a-5dee-4e5a-924f-bf7722669410"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(pressPoint=0.5,behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1742dc90-a724-4e6c-887d-9d6b88e61b0f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press(pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NotchArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34317ee3-59f0-4f64-835c-315cdf047f68"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_Fire = m_Gameplay.FindAction("Fire", throwIfNotFound: true);
        m_Gameplay_DodgeRoll = m_Gameplay.FindAction("DodgeRoll", throwIfNotFound: true);
        m_Gameplay_NotchArrow = m_Gameplay.FindAction("NotchArrow", throwIfNotFound: true);
        m_Gameplay_PullArrow = m_Gameplay.FindAction("PullArrow", throwIfNotFound: true);
    }

    ~PlayerControls()
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Rotate;
    private readonly InputAction m_Gameplay_Fire;
    private readonly InputAction m_Gameplay_DodgeRoll;
    private readonly InputAction m_Gameplay_NotchArrow;
    private readonly InputAction m_Gameplay_PullArrow;
    public struct GameplayActions
    {
        private PlayerControls m_Wrapper;
        public GameplayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputAction @Fire => m_Wrapper.m_Gameplay_Fire;
        public InputAction @DodgeRoll => m_Wrapper.m_Gameplay_DodgeRoll;
        public InputAction @NotchArrow => m_Wrapper.m_Gameplay_NotchArrow;
        public InputAction @PullArrow => m_Wrapper.m_Gameplay_PullArrow;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                DodgeRoll.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodgeRoll;
                DodgeRoll.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodgeRoll;
                DodgeRoll.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodgeRoll;
                NotchArrow.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNotchArrow;
                NotchArrow.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNotchArrow;
                NotchArrow.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNotchArrow;
                PullArrow.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPullArrow;
                PullArrow.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPullArrow;
                PullArrow.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPullArrow;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Rotate.started += instance.OnRotate;
                Rotate.performed += instance.OnRotate;
                Rotate.canceled += instance.OnRotate;
                Fire.started += instance.OnFire;
                Fire.performed += instance.OnFire;
                Fire.canceled += instance.OnFire;
                DodgeRoll.started += instance.OnDodgeRoll;
                DodgeRoll.performed += instance.OnDodgeRoll;
                DodgeRoll.canceled += instance.OnDodgeRoll;
                NotchArrow.started += instance.OnNotchArrow;
                NotchArrow.performed += instance.OnNotchArrow;
                NotchArrow.canceled += instance.OnNotchArrow;
                PullArrow.started += instance.OnPullArrow;
                PullArrow.performed += instance.OnPullArrow;
                PullArrow.canceled += instance.OnPullArrow;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnDodgeRoll(InputAction.CallbackContext context);
        void OnNotchArrow(InputAction.CallbackContext context);
        void OnPullArrow(InputAction.CallbackContext context);
    }
}
