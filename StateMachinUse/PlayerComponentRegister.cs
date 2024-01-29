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
        // ロケーターにコンポーネントを登録する
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

        // InputSystemの入力開始時の処理を登録する
        playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        // InputSystemの入力終了時の処理を登録する
        playerInputSystem.Disable();
    }
}