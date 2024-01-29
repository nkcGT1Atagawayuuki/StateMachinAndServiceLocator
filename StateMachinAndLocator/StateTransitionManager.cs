using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    // AddTransitionで遷移条件の登録が出来る
    // IStaterを継承しているクラスからTryTransitionToNextStateを利用してステートの変更を行う

    public class StateTransitionManager<T> where T : IStater
    {
        private StateMachineBaser stateMachineBaser;
        private Dictionary<T, T>  transitionDic = new Dictionary<T, T>();

        /// <summary>
        /// ステートの遷移条件を追加する
        /// </summary>
        public void AddTransition(T startState, T nextState)
        {
            transitionDic.Add(startState, nextState);
        }

        /// <summary>
        /// 遷移条件が登録されているか確認をして状態を変更する
        /// </summary>
        public void TryTransitionToNextState(T currentState, T nextState)
        {
            if (!transitionDic.TryGetValue(currentState, out nextState))
            {
                Debug.LogError("遷移条件が見つかりませんでした");
                return;
            }

            NextTransition(nextState);
        }

        /// <summary>
        /// ステートを変更する
        /// </summary>
        /// <param name="nextState">変更したい次のステートを入れる</param>
        private void NextTransition(IStater nextState)
        {
            stateMachineBaser.CurrentState.OnExit();
            stateMachineBaser.CurrentState = nextState;
            stateMachineBaser.CurrentState.OnEnter();
        }
    }
}