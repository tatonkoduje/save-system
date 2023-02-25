using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace com.maapiid.savesystem
{
    public abstract class FileManager : Singleton<FileManager>
    {
        public static string Path { get; set; } = Application.persistentDataPath;
        public static string Filename { get; set; } = "data.aru";
        
        internal static void SaveFile(object state)
        {
            var path = Path + "/" + Filename;
            
            using var stream = File.Open(path, FileMode.Create);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
            stream.Close();
            
            Debug.Log("Saved in " + path);
        }
        
        internal static IDictionary<string, object> LoadFile()
        {
            var path = Path + "/" + Filename;
            
            if (!File.Exists(path))
            {
                Debug.LogWarning("Not found files in location: " + Application.persistentDataPath);
                return new Dictionary<string, object>();
            }

            using var stream = File.Open(path, FileMode.Open);
            var formatter = new BinaryFormatter();
            var state = formatter.Deserialize(stream) as IDictionary<string, object>;
            stream.Close();
            return state;
        }
    }
}