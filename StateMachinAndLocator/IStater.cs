namespace StateMachine
{
    public interface IStater 
    {
        /// <summary>
        /// �X�e�[�g�̊J�n���Ɏ��s�����
        /// </summary>
        void OnEnter();

        /// <summary>
        /// �X�e�[�g�̏I�����Ɏ��s�����
        /// </summary>
        void OnExit();

        /// <summary>
        /// �Œ�t���[���Ԋu�Ŏ��s�����
        /// </summary>
        void OnFixedUpdate();

        /// <summary>
        /// ���t���[���̍Ō�Ɏ��s�����
        /// </summary>
        void OnLateUpdate();

        /// <summary>
        /// ���t���[���Ԋu�Ŏ��s�����
        /// </summary>
        void OnUpdate();
    }
}