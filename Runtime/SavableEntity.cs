using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.maapiid.savesystem
{
    public class SavableEntity : MonoBehaviour
    {
        public string Id => id;
        
        [SerializeField] private string id = string.Empty;
        [ContextMenu("Generate Id")]
        private void GenerateId() => id = Guid.NewGuid().ToString();

        public object CaptureState()
        {
            var state = new Dictionary<string, object>();
            GetComponents<ISavable>().ToList().ForEach(e => state[e.GetType().ToString()] = e.CaptureState());
            return state;
        }

        public void RestoreState(object state)
        {
            var stateDict = state as IDictionary<string, object>;
            GetComponents<ISavable>().ToList().ForEach(e =>
            {
                var typeName = e.GetType().ToString();
                if(stateDict!.TryGetValue(typeName, out var value)) e.RestoreState(value);
            });
        }
    }
}