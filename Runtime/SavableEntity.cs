using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.maapiid.savesystem
{
    public class SavableEntity : MonoBehaviour
    {
        [SerializeField] private string id = string.Empty;

        public string Id => id;

        [ContextMenu("Generate Id")]
        private void GenerateId() => id = Guid.NewGuid().ToString();

        public object CaptureState()
        {
            var state = new Dictionary<string, object>();

            foreach (var savable in GetComponents<ISavable>())
            {
                state[savable.GetType().ToString()] = savable.CaptureState();
            }

            return state;
        }

        public void RestoreState(object state)
        {
            var stateDictionary = state as Dictionary<string, object>;

            foreach (var savable in GetComponents<ISavable>())
            {
                string typeName = savable.GetType().ToString();

                if (stateDictionary.TryGetValue(typeName, out object value))
                {
                    savable.RestoreState(value);
                }
            }
        }
    }
}