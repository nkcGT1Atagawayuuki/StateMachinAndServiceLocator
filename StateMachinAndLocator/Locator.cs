using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public static class Locator<T>
    {
        // コンポーネントの登録を保持する変数
        private static Dictionary<int, T> instanceDic = new Dictionary<int, T>();

        // idの番号先に登録と解除を行う事が出来る
        // 番号を設定しない場合は0番が設定される

        /// <summary>
        /// コンポーネントを登録する
        /// </summary>
        public static void Register(T instance, int id = 0)
        {
            instanceDic[id] = instance;
        }

        /// <summary>
        /// コンポーネントの登録を解除する
        /// </summary>
        public static void Unregister(int id = 0)
        {
            if (!instanceDic.ContainsKey(id))
            {
                Debug.LogError("コンポーネントが登録されてません");
                return;
            }

            instanceDic[id] = default;
        }

        /// <summary>
        /// コンポーネントの登録を全て解除する
        /// </summary>
        public static void UnregisterAll()
        {
            instanceDic.Clear();
        }

        /// <summary>
        /// 登録されているコンポーネントを取得する
        /// </summary>
        /// <returns>登録されていない時は処理を行わない</returns>
        public static T GetInstance(int id = 0)
        {
            if (!instanceDic.ContainsKey(id))
            {
                Debug.LogError("コンポーネントが登録されてません");
                return default;
            }

            return instanceDic[id];
        }
    }
} 
