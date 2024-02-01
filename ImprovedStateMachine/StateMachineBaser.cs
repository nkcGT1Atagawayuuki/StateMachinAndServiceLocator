using System.Collections.Generic;
using UnityEngine;

public abstract class Stater
{
    /// <summary>
    /// ステートの開始時に実行する
    /// </summary>
    public virtual void OnEnter() { }

    /// <summary>
    /// ステートの終了時に実行する
    /// </summary>
    public virtual void OnExit() { }

    /// <summary>
    /// 固定フレーム実行される
    /// </summary>
    public virtual void OnFixedUpdate() { }


    /// <summary>
    /// 毎フレームの最後に実行する
    /// </summary>
    public virtual void OnLateUpadate() { }

    /// <summary>
    /// 毎フレーム実行される
    /// </summary>
    public virtual void OnUpdate() { }
}

public class StateMachineBaser<T> : Stater where T : Stater
{
    public  Stater           CurrentState  { get; private set; }
    private Dictionary<T, T> transitionDic = new Dictionary<T, T>();

    public override void OnEnter()
    {
        CurrentState?.OnEnter();
    }

    public override void OnExit()
    {
        CurrentState?.OnExit();
    }

    public override void OnFixedUpdate()
    {
        CurrentState?.OnFixedUpdate();
    }

    public override void OnLateUpadate()
    {
        CurrentState?.OnLateUpadate();
    }

    public override void OnUpdate()
    {
        CurrentState?.OnUpdate();
    }

    /// <summary>
    /// 遷移条件を登録する
    /// </summary>
    public void AddTranstition(T from, T to)
    {
        transitionDic.Add(from, to);
    }

    /// <summary>
    /// ステートの変更を試みる
    /// </summary>
    public void TryTransitionToNextState(T currentState, T nextState)
    {
        if(!transitionDic.TryGetValue(currentState, out T transition))
        {
            Debug.LogError("遷移条件が見つかりませんでした。");
            return;
        }

        ChangeState(nextState);
    }

    /// <summary>
    /// ステートを変更する
    /// </summary>
    private void ChangeState(Stater nextState)
    {
        CurrentState.OnExit();
        CurrentState = nextState;
        CurrentState.OnEnter();
    }
}