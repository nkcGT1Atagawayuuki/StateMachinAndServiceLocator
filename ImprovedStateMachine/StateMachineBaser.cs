using System.Collections.Generic;
using UnityEngine;

public abstract class Stater
{
    /// <summary>
    /// �X�e�[�g�̊J�n���Ɏ��s����
    /// </summary>
    public virtual void OnEnter() { }

    /// <summary>
    /// �X�e�[�g�̏I�����Ɏ��s����
    /// </summary>
    public virtual void OnExit() { }

    /// <summary>
    /// �Œ�t���[�����s�����
    /// </summary>
    public virtual void OnFixedUpdate() { }


    /// <summary>
    /// ���t���[���̍Ō�Ɏ��s����
    /// </summary>
    public virtual void OnLateUpadate() { }

    /// <summary>
    /// ���t���[�����s�����
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
    /// �J�ڏ�����o�^����
    /// </summary>
    public void AddTranstition(T from, T to)
    {
        transitionDic.Add(from, to);
    }

    /// <summary>
    /// �X�e�[�g�̕ύX�����݂�
    /// </summary>
    public void TryTransitionToNextState(T currentState, T nextState)
    {
        if(!transitionDic.TryGetValue(currentState, out T transition))
        {
            Debug.LogError("�J�ڏ�����������܂���ł����B");
            return;
        }

        ChangeState(nextState);
    }

    /// <summary>
    /// �X�e�[�g��ύX����
    /// </summary>
    private void ChangeState(Stater nextState)
    {
        CurrentState.OnExit();
        CurrentState = nextState;
        CurrentState.OnEnter();
    }
}