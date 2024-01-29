namespace StateMachine
{
    public class StateMachineBaser
    {
        // 現在のステート
        public IStater CurrentState { get; set; }

        /// <summary>
        /// ステートを初期化する
        /// </summary>
        /// <param name="stater">最初のステートを入れる</param>
        public void Initilize(IStater stater)
        {
            CurrentState = stater;
            CurrentState.OnEnter();
        }

        /// <summary>
        /// CurrentStateのFixedUpdateを実行する
        /// </summary>
        public void FixedUpdate()
        {
            if(CurrentState != null)
            {
                CurrentState.OnFixedUpdate();
            }
        }

        /// <summary>
        /// CurrentStateのLateUpdateを実行する
        /// </summary>
        public void LateUpdate()
        {
            if (CurrentState != null)
            {
                CurrentState.OnLateUpdate();
            }
        }

        /// <summary>
        /// CurrentStateのUpdateを実行する
        /// </summary>
        public void Update()
        {
            if(CurrentState != null)
            {
                CurrentState.OnUpdate();
            }
        }
    }
}
