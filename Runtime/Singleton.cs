using System;
using System.Reflection;

namespace com.maapiid.savesystem
{
    public abstract class Singleton<T> where T : Singleton<T>
    {
        public static T Instance => Lazy.Value;
        private static readonly Lazy<T> Lazy = new(Create);
        
        private static T Create()
        {
            var constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
            return (T) constructor!.Invoke(null);
        }
    }
}