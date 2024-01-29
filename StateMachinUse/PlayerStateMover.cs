using PlayerInput;
using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerStateMover : IStater
{
    private PlayerInputer playerInputer;
    private bool isInilizae = false;

    void IStater.OnEnter()
    {
        Initilaize();
    }

    void IStater.OnExit()
    {
    }

    void IStater.OnFixedUpdate()
    {
    }

    void IStater.OnLateUpdate() { }

    void IStater.OnUpdate()
    {
        // �v���C���[�̓��͂𖈃t���[���X�V���� 
        playerInputer.UpdateMoveInput();
        playerInputer.HasUpdateJumpInput();
        playerInputer.HasUpdateDodgeInput();
        playerInputer.HasUpdateAttackInput();

        // PlayerInputParamater�̓��͂�PlayerInputer�̓��͂𓯊�������
        playerInputer.UpdateSyncInputParameters();
    }

    private void Initilaize()
    {
        if (!isInilizae)
        {
            playerInputer = Locator<PlayerInputer>.GetInstance();
            playerInputer.Initilaize();
            isInilizae = true;
        }
    }
}
