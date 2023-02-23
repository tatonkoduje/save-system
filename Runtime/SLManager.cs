using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace com.maapiid.savesystem
{
   
    public class SLManager : MonoBehaviour
    {
        private string Path => $"{Application.persistentDataPath}/data.aru";

        [ContextMenu("Save")]
        public void Save()
        {
            var state = LoadFile();
            CaptureState(state);
            SaveFile(state);
        }

        [ContextMenu("Load")]
        public void Load()
        {
            var state = LoadFile();
            RestoreState(state);
        }
        
        private Dictionary<string, object> LoadFile()
        {
            if (!File.Exists(Path))
            {
                return new Dictionary<string, object>();
            }

            using (FileStream stream = File.Open(Path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as Dictionary<string, object>;
            }
        }

        private void SaveFile(object state)
        {
            using (var stream = File.Open(Path, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }
        
        private void CaptureState(Dictionary<string, object> state)
        {
            foreach (var savable in FindObjectsOfType<SavableEntity>())
            {
                state[savable.Id] = savable.CaptureState();
            }
        }

        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (var savable in FindObjectsOfType<SavableEntity>())
            {
                if (state.TryGetValue(savable.Id, out object value))
                {
                    savable.RestoreState(value);
                }
            }
        }
    }
}