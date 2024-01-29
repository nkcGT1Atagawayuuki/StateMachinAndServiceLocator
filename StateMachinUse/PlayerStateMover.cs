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
        // プレイヤーの入力を毎フレーム更新する 
        playerInputer.UpdateMoveInput();
        playerInputer.HasUpdateJumpInput();
        playerInputer.HasUpdateDodgeInput();
        playerInputer.HasUpdateAttackInput();

        // PlayerInputParamaterの入力とPlayerInputerの入力を同期させる
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
