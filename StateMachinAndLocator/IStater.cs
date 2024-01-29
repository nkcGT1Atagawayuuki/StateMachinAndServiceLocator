namespace StateMachine
{
    public interface IStater 
    {
        /// <summary>
        /// ステートの開始時に実行される
        /// </summary>
        void OnEnter();

        /// <summary>
        /// ステートの終了時に実行される
        /// </summary>
        void OnExit();

        /// <summary>
        /// 固定フレーム間隔で実行される
        /// </summary>
        void OnFixedUpdate();

        /// <summary>
        /// 毎フレームの最後に実行される
        /// </summary>
        void OnLateUpdate();

        /// <summary>
        /// 毎フレーム間隔で実行される
        /// </summary>
        void OnUpdate();
    }
}