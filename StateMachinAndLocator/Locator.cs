using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public static class Locator<T>
    {
        // �R���|�[�l���g�̓o�^��ێ�����ϐ�
        private static Dictionary<int, T> instanceDic = new Dictionary<int, T>();

        // id�̔ԍ���ɓo�^�Ɖ������s�������o����
        // �ԍ���ݒ肵�Ȃ��ꍇ��0�Ԃ��ݒ肳���

        /// <summary>
        /// �R���|�[�l���g��o�^����
        /// </summary>
        public static void Register(T instance, int id = 0)
        {
            instanceDic[id] = instance;
        }

        /// <summary>
        /// �R���|�[�l���g�̓o�^����������
        /// </summary>
        public static void Unregister(int id = 0)
        {
            if (!instanceDic.ContainsKey(id))
            {
                Debug.LogError("�R���|�[�l���g���o�^����Ă܂���");
                return;
            }

            instanceDic[id] = default;
        }

        /// <summary>
        /// �R���|�[�l���g�̓o�^��S�ĉ�������
        /// </summary>
        public static void UnregisterAll()
        {
            instanceDic.Clear();
        }

        /// <summary>
        /// �o�^����Ă���R���|�[�l���g���擾����
        /// </summary>
        /// <returns>�o�^����Ă��Ȃ����͏������s��Ȃ�</returns>
        public static T GetInstance(int id = 0)
        {
            if (!instanceDic.ContainsKey(id))
            {
                Debug.LogError("�R���|�[�l���g���o�^����Ă܂���");
                return default;
            }

            return instanceDic[id];
        }
    }
} 
