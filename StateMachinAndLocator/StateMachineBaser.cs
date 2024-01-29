namespace StateMachine
{
    public class StateMachineBaser
    {
        // ���݂̃X�e�[�g
        public IStater CurrentState { get; set; }

        /// <summary>
        /// �X�e�[�g������������
        /// </summary>
        /// <param name="stater">�ŏ��̃X�e�[�g������</param>
        public void Initilize(IStater stater)
        {
            CurrentState = stater;
            CurrentState.OnEnter();
        }

        /// <summary>
        /// CurrentState��FixedUpdate�����s����
        /// </summary>
        public void FixedUpdate()
        {
            if(CurrentState != null)
            {
                CurrentState.OnFixedUpdate();
            }
        }

        /// <summary>
        /// CurrentState��LateUpdate�����s����
        /// </summary>
        public void LateUpdate()
        {
            if (CurrentState != null)
            {
                CurrentState.OnLateUpdate();
            }
        }

        /// <summary>
        /// CurrentState��Update�����s����
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
