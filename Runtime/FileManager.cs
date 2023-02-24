using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace com.maapiid.savesystem
{
    public abstract class FileManager : Singleton<FileManager>
    {
        private static string Path => $"{Application.persistentDataPath}/data.aru";
        
        internal static void SaveFile(object state)
        {
            using var stream = File.Open(Path, FileMode.Create);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
            stream.Close();
            
            Debug.Log("Saved in " + Path);
        }
        
        internal static IDictionary<string, object> LoadFile()
        {
            if (!File.Exists(Path))
            {
                Debug.LogWarning("No saved files in location: " + Application.persistentDataPath);
                return new Dictionary<string, object>();
            }

            using var stream = File.Open(Path, FileMode.Open);
            var formatter = new BinaryFormatter();
            var state = formatter.Deserialize(stream) as IDictionary<string, object>;
            stream.Close();
            return state;
        }
    }
}