using UnityEngine;

namespace com.maapiid.savesystem
{
    public interface ISavableData
    {
        public void Restore(MonoBehaviour mb_object);
    }
}