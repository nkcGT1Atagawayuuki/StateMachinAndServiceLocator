using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    // AddTransition�őJ�ڏ����̓o�^���o����
    // IStater���p�����Ă���N���X����TryTransitionToNextState�𗘗p���ăX�e�[�g�̕ύX���s��

    public class StateTransitionManager<T> where T : IStater
    {
        private StateMachineBaser stateMachineBaser;
        private Dictionary<T, T>  transitionDic = new Dictionary<T, T>();

        /// <summary>
        /// �X�e�[�g�̑J�ڏ�����ǉ�����
        /// </summary>
        public void AddTransition(T startState, T nextState)
        {
            transitionDic.Add(startState, nextState);
        }

        /// <summary>
        /// �J�ڏ������o�^����Ă��邩�m�F�����ď�Ԃ�ύX����
        /// </summary>
        public void TryTransitionToNextState(T currentState, T nextState)
        {
            if (!transitionDic.TryGetValue(currentState, out nextState))
            {
                Debug.LogError("�J�ڏ�����������܂���ł���");
                return;
            }

            NextTransition(nextState);
        }

        /// <summary>
        /// �X�e�[�g��ύX����
        /// </summary>
        /// <param name="nextState">�ύX���������̃X�e�[�g������</param>
        private void NextTransition(IStater nextState)
        {
            stateMachineBaser.CurrentState.OnExit();
            stateMachineBaser.CurrentState = nextState;
            stateMachineBaser.CurrentState.OnEnter();
        }
    }
}