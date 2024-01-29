using UnityEngine;
using Utility;

public class PlayerComponentRegister : MonoBehaviour
{
                     private PlayerInputSystem     playerInputSystem;
    [SerializeField] private Animator              animator;
    [SerializeField] private new Rigidbody         rigidbody;
    [SerializeField] private PhysicMaterial        physicMaterial;
    [SerializeField] private PlayerStatusParameter playerStatusParameter;
    [SerializeField] private PlayerInputParameter  playerInputParameter;

    private void Awake()
    {
        // ���P�[�^�[�ɃR���|�[�l���g��o�^����
        Locator<PlayerInputSystem>     .Register(playerInputSystem);
        Locator<Animator>              .Register(animator);
        Locator<Rigidbody>             .Register(rigidbody);
        Locator<PhysicMaterial>        .Register(physicMaterial);
        Locator<PlayerStatusParameter> .Register(playerStatusParameter);
        Locator<PlayerInputParameter>  .Register(playerInputParameter);
    }

    private void OnEnable()
    {
        playerInputSystem = new PlayerInputSystem();

        // InputSystem�̓��͊J�n���̏�����o�^����
        playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        // InputSystem�̓��͏I�����̏�����o�^����
        playerInputSystem.Disable();
    }
}