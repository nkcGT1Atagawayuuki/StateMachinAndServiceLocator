using UnityEngine;
using Utility;

namespace PlayerInput
{
    public class PlayerInputer
    {
        private PlayerInputSystem    playerInputSystem;
        private PlayerInputParameter playerInputParameter;

        private bool canMoveInput   = true;
        private bool canJumpInput   = true;
        private bool canDodgeInput  = true;
        private bool canAttackInput = true;

        public void Initilaize()
        {
            playerInputSystem    = Locator<PlayerInputSystem>    .GetInstance();
            playerInputParameter = Locator<PlayerInputParameter> .GetInstance();
        }

        public Vector2 UpdateMoveInput()
        {
            if (!canMoveInput)
            {
                return Vector2.zero;
            }

            Vector2 moveInputDir = playerInputSystem.Player.Move.ReadValue<Vector2>();
            return new Vector2(moveInputDir.x, moveInputDir.y).normalized;
        }

        public bool HasUpdateJumpInput()
        {
            if (!canJumpInput)
            {
                return false;
            }

            return playerInputSystem.Player.Jump.triggered;
        }

        public bool HasUpdateDodgeInput()
        {
            if(!canDodgeInput)
            {
                return false;
            }

            return playerInputSystem.Player.Dodge.triggered;
        }

        public bool HasUpdateAttackInput()
        {
            if (!canAttackInput)
            {
                return false;
            }

            return playerInputSystem.Player.Attack.triggered;
        }

        public void UpdateSyncInputParameters()
        {
            // プレイヤーの入力をInputParameterに同期させる
            playerInputParameter.MoveInputDir   = UpdateMoveInput();
            playerInputParameter.HasJumpInput   = HasUpdateJumpInput();
            playerInputParameter.HasDodgeInput  = HasUpdateDodgeInput();
            playerInputParameter.HasAttackInput = HasUpdateAttackInput();

            // InputParameterの入力可能判定と同期させる
            canMoveInput   = playerInputParameter.CanMoveInput;
            canJumpInput   = playerInputParameter.CanJumpInput;
            canDodgeInput  = playerInputParameter.CanDodgeInput;
            canAttackInput = playerInputParameter.CanAttackInput;
        }
    }
}