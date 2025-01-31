// GENERATED AUTOMATICALLY FROM 'Assets/Data/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""98687c1e-dd37-4f7f-8cb8-a338bf3f3960"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4cc01ceb-c1ee-4361-8d80-0fe4d5c2cfe9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ad41ac1e-5b9a-416f-96cd-1e2c7c52cc95"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockOnTargetLeft"",
                    ""type"": ""Button"",
                    ""id"": ""fb04d81f-93af-4d65-993d-77499aaadb3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockOnTargetRight"",
                    ""type"": ""Button"",
                    ""id"": ""6059fc23-8197-4e4a-bfff-5114f632a38b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""95353525-5c68-40f8-928c-d06132ef0433"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c113013c-a46b-42f3-b53f-e09c6fadca40"",
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
                    ""id"": ""4be5f1b7-7567-48cd-800f-2207ffa15732"",
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
                    ""id"": ""82271043-787c-4811-9705-2aa0e6f6cf51"",
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
                    ""id"": ""043e9401-88b8-403c-be78-9dee22d50553"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD(Controller)"",
                    ""id"": ""134149f4-9cc5-4867-a41c-7da0d3cbda7e"",
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
                    ""id"": ""c218f34d-361f-4d3a-87b1-627a8f3a595b"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fcd14ddb-4e8a-4d73-8c3f-b25bb62cfd25"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4e925ca7-c9c0-4fb1-a31e-c3d20307b38a"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""951f2822-3cf9-46d8-ab31-6f11e344b35a"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d9bd1e22-feb2-42af-a7f0-5c9e13c9e4bc"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""becd781c-d083-4636-a449-1e1943536d28"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab0b7f25-95cf-490e-9faf-971cd2eb7ed3"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOnTargetLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4e0a8f7-b813-4044-bc8f-7e3448d1c443"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOnTargetLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d063eec-cbe7-422a-904e-05d607570fec"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOnTargetRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccbd1b22-dcdf-4cdb-a8ab-33313fa36473"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOnTargetRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerActions"",
            ""id"": ""d91eb8da-ac41-4cc8-94bd-23d76432bbfe"",
            ""actions"": [
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""48952d7a-9d99-4878-ae4a-46a3e45cf3df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""726bb15c-332b-419b-a452-1ea1949cb95b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""b0064c54-7a8f-42ef-9607-bbcd3504047f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""41a7efc3-9044-402a-bb71-eca9ec34efb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RegularAttack"",
                    ""type"": ""Button"",
                    ""id"": ""9aa7d6ea-4634-4196-9e8c-cd1301daedff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpecialAttack"",
                    ""type"": ""Button"",
                    ""id"": ""094a4503-c6f9-4dcd-a3ea-c363b40b8187"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""fe866fa6-69ae-46ac-9a97-52cb42dd0e69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CombieAttack"",
                    ""type"": ""Button"",
                    ""id"": ""609ce1f0-2cd7-4d25-b2fc-96fde95e1d80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponAbility"",
                    ""type"": ""Button"",
                    ""id"": ""b4ba5c9f-8fd7-4c8f-aad8-5156a08f9563"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WeaponSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""3d6f7bd7-d114-4ee3-ab05-140472c31df5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BaGuaSystem"",
                    ""type"": ""Button"",
                    ""id"": ""1d0d4eb7-ef0a-4d44-a35b-3d8ad89ea66a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""74e498ac-4e40-4313-9e66-648679f706a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b916778-ac73-43a7-89b8-475842997262"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8f027c1-f5d4-4e34-9d5e-31731b40a839"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a84c78c5-2fde-4be1-b09f-4f885bf37aa5"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b115111-e6f3-4198-8ef8-f30d87599b4a"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc13ceae-39bf-4894-b217-65ae0b54d497"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RegularAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f11a3064-1f81-427f-b274-5b8948ee87f6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RegularAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d443d7d3-7e45-4355-bdc5-d0aa6c4e63f7"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24b17f98-3621-4afa-98c9-2097d34b84b1"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a67ec06d-6376-48b1-87e5-b910fc3b3aef"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46acea21-3806-4e67-8855-3605dadf52c3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""440439c8-df4e-419d-8a93-d99598eaf1f9"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CombieAttack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""083d7324-5570-4fcd-8ddf-012931b12187"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CombieAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""30491f2d-0ed9-431c-a2c6-16a009e43ad7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CombieAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""f50ababf-df77-4bca-afe3-189f0431b985"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CombieAttack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""194daf27-1de8-467e-a3c8-a46d6ba9759e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CombieAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""a0d45499-1834-4e38-b1dd-20c82a9598c3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CombieAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5f693efb-75bf-4031-97d1-539972c117df"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1f0a00c-2ab9-4a95-9fa1-76e69be633ee"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84dac613-f1ae-46de-8bef-abf2e116670e"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8f8178b-6b61-407b-a893-0b2975c543f8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""713a308a-dacc-49d4-b22f-704a59eafe3f"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BaGuaSystem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca78bfcb-cdf3-4e44-97d0-0bfb87706476"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BaGuaSystem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""076c362e-3086-44ee-ae1e-6654ce67d68a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7943e34d-fe7e-4aed-bc60-3229dd82c464"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIActions"",
            ""id"": ""eb5d7998-541f-45c3-9563-19b8c8731391"",
            ""actions"": [
                {
                    ""name"": ""Backpack"",
                    ""type"": ""Button"",
                    ""id"": ""68bc58b3-ad9c-4a4c-b1f3-54bcc8fd48fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        m_PlayerMovement_LockOnTargetLeft = m_PlayerMovement.FindAction("LockOnTargetLeft", throwIfNotFound: true);
        m_PlayerMovement_LockOnTargetRight = m_PlayerMovement.FindAction("LockOnTargetRight", throwIfNotFound: true);
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_LockOn = m_PlayerActions.FindAction("LockOn", throwIfNotFound: true);
        m_PlayerActions_Roll = m_PlayerActions.FindAction("Roll", throwIfNotFound: true);
        m_PlayerActions_Sprint = m_PlayerActions.FindAction("Sprint", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActions_RegularAttack = m_PlayerActions.FindAction("RegularAttack", throwIfNotFound: true);
        m_PlayerActions_SpecialAttack = m_PlayerActions.FindAction("SpecialAttack", throwIfNotFound: true);
        m_PlayerActions_Interact = m_PlayerActions.FindAction("Interact", throwIfNotFound: true);
        m_PlayerActions_CombieAttack = m_PlayerActions.FindAction("CombieAttack", throwIfNotFound: true);
        m_PlayerActions_WeaponAbility = m_PlayerActions.FindAction("WeaponAbility", throwIfNotFound: true);
        m_PlayerActions_WeaponSwitch = m_PlayerActions.FindAction("WeaponSwitch", throwIfNotFound: true);
        m_PlayerActions_BaGuaSystem = m_PlayerActions.FindAction("BaGuaSystem", throwIfNotFound: true);
        m_PlayerActions_Crouch = m_PlayerActions.FindAction("Crouch", throwIfNotFound: true);
        // UIActions
        m_UIActions = asset.FindActionMap("UIActions", throwIfNotFound: true);
        m_UIActions_Backpack = m_UIActions.FindAction("Backpack", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Camera;
    private readonly InputAction m_PlayerMovement_LockOnTargetLeft;
    private readonly InputAction m_PlayerMovement_LockOnTargetRight;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputAction @LockOnTargetLeft => m_Wrapper.m_PlayerMovement_LockOnTargetLeft;
        public InputAction @LockOnTargetRight => m_Wrapper.m_PlayerMovement_LockOnTargetRight;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @LockOnTargetLeft.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetLeft;
                @LockOnTargetLeft.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetLeft;
                @LockOnTargetLeft.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetLeft;
                @LockOnTargetRight.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetRight;
                @LockOnTargetRight.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetRight;
                @LockOnTargetRight.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLockOnTargetRight;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @LockOnTargetLeft.started += instance.OnLockOnTargetLeft;
                @LockOnTargetLeft.performed += instance.OnLockOnTargetLeft;
                @LockOnTargetLeft.canceled += instance.OnLockOnTargetLeft;
                @LockOnTargetRight.started += instance.OnLockOnTargetRight;
                @LockOnTargetRight.performed += instance.OnLockOnTargetRight;
                @LockOnTargetRight.canceled += instance.OnLockOnTargetRight;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_LockOn;
    private readonly InputAction m_PlayerActions_Roll;
    private readonly InputAction m_PlayerActions_Sprint;
    private readonly InputAction m_PlayerActions_Jump;
    private readonly InputAction m_PlayerActions_RegularAttack;
    private readonly InputAction m_PlayerActions_SpecialAttack;
    private readonly InputAction m_PlayerActions_Interact;
    private readonly InputAction m_PlayerActions_CombieAttack;
    private readonly InputAction m_PlayerActions_WeaponAbility;
    private readonly InputAction m_PlayerActions_WeaponSwitch;
    private readonly InputAction m_PlayerActions_BaGuaSystem;
    private readonly InputAction m_PlayerActions_Crouch;
    public struct PlayerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LockOn => m_Wrapper.m_PlayerActions_LockOn;
        public InputAction @Roll => m_Wrapper.m_PlayerActions_Roll;
        public InputAction @Sprint => m_Wrapper.m_PlayerActions_Sprint;
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputAction @RegularAttack => m_Wrapper.m_PlayerActions_RegularAttack;
        public InputAction @SpecialAttack => m_Wrapper.m_PlayerActions_SpecialAttack;
        public InputAction @Interact => m_Wrapper.m_PlayerActions_Interact;
        public InputAction @CombieAttack => m_Wrapper.m_PlayerActions_CombieAttack;
        public InputAction @WeaponAbility => m_Wrapper.m_PlayerActions_WeaponAbility;
        public InputAction @WeaponSwitch => m_Wrapper.m_PlayerActions_WeaponSwitch;
        public InputAction @BaGuaSystem => m_Wrapper.m_PlayerActions_BaGuaSystem;
        public InputAction @Crouch => m_Wrapper.m_PlayerActions_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @LockOn.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @Roll.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Sprint.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSprint;
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @RegularAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRegularAttack;
                @RegularAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRegularAttack;
                @RegularAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRegularAttack;
                @SpecialAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSpecialAttack;
                @SpecialAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSpecialAttack;
                @SpecialAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSpecialAttack;
                @Interact.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @CombieAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCombieAttack;
                @CombieAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCombieAttack;
                @CombieAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCombieAttack;
                @WeaponAbility.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeaponAbility;
                @WeaponAbility.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeaponAbility;
                @WeaponAbility.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeaponAbility;
                @WeaponSwitch.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeaponSwitch;
                @WeaponSwitch.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeaponSwitch;
                @WeaponSwitch.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWeaponSwitch;
                @BaGuaSystem.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBaGuaSystem;
                @BaGuaSystem.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBaGuaSystem;
                @BaGuaSystem.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBaGuaSystem;
                @Crouch.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RegularAttack.started += instance.OnRegularAttack;
                @RegularAttack.performed += instance.OnRegularAttack;
                @RegularAttack.canceled += instance.OnRegularAttack;
                @SpecialAttack.started += instance.OnSpecialAttack;
                @SpecialAttack.performed += instance.OnSpecialAttack;
                @SpecialAttack.canceled += instance.OnSpecialAttack;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @CombieAttack.started += instance.OnCombieAttack;
                @CombieAttack.performed += instance.OnCombieAttack;
                @CombieAttack.canceled += instance.OnCombieAttack;
                @WeaponAbility.started += instance.OnWeaponAbility;
                @WeaponAbility.performed += instance.OnWeaponAbility;
                @WeaponAbility.canceled += instance.OnWeaponAbility;
                @WeaponSwitch.started += instance.OnWeaponSwitch;
                @WeaponSwitch.performed += instance.OnWeaponSwitch;
                @WeaponSwitch.canceled += instance.OnWeaponSwitch;
                @BaGuaSystem.started += instance.OnBaGuaSystem;
                @BaGuaSystem.performed += instance.OnBaGuaSystem;
                @BaGuaSystem.canceled += instance.OnBaGuaSystem;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // UIActions
    private readonly InputActionMap m_UIActions;
    private IUIActionsActions m_UIActionsActionsCallbackInterface;
    private readonly InputAction m_UIActions_Backpack;
    public struct UIActionsActions
    {
        private @PlayerControls m_Wrapper;
        public UIActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Backpack => m_Wrapper.m_UIActions_Backpack;
        public InputActionMap Get() { return m_Wrapper.m_UIActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActionsActions set) { return set.Get(); }
        public void SetCallbacks(IUIActionsActions instance)
        {
            if (m_Wrapper.m_UIActionsActionsCallbackInterface != null)
            {
                @Backpack.started -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnBackpack;
                @Backpack.performed -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnBackpack;
                @Backpack.canceled -= m_Wrapper.m_UIActionsActionsCallbackInterface.OnBackpack;
            }
            m_Wrapper.m_UIActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Backpack.started += instance.OnBackpack;
                @Backpack.performed += instance.OnBackpack;
                @Backpack.canceled += instance.OnBackpack;
            }
        }
    }
    public UIActionsActions @UIActions => new UIActionsActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnLockOnTargetLeft(InputAction.CallbackContext context);
        void OnLockOnTargetRight(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnLockOn(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRegularAttack(InputAction.CallbackContext context);
        void OnSpecialAttack(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnCombieAttack(InputAction.CallbackContext context);
        void OnWeaponAbility(InputAction.CallbackContext context);
        void OnWeaponSwitch(InputAction.CallbackContext context);
        void OnBaGuaSystem(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface IUIActionsActions
    {
        void OnBackpack(InputAction.CallbackContext context);
    }
}
