using System;
using UnityEngine;

namespace com.maapiid.savesystem
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance => Lazy.Value;
        private static readonly Lazy<T> Lazy = new(Create);
        
        private static T Create()
        {
            var owner = new GameObject($"{typeof(T).Name} (singleton)");
            var instance = owner.AddComponent<T>();
            DontDestroyOnLoad(owner);
            return instance;
        }
    }
}