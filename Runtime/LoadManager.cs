using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace com.maapiid.savesystem
{
    internal class LoadManager
    {
        private BinaryFormatter binaryFormatter;
        private FileStream stream;
        private string path;
        private string filename;
        private string extension;

        internal LoadManager()
        {
            this.binaryFormatter = new BinaryFormatter();
            this.path = "/";
            this.filename = "gamedata";
            this.extension = ".aru";
        }
        
        internal ISavableData Load()
        {
            path = Application.persistentDataPath + this.filename + this.extension;

            if (File.Exists(this.path))
            {
                stream = new FileStream(this.path, FileMode.Open);
                ISavableData data = binaryFormatter.Deserialize(stream) as ISavableData;
                stream.Close();

                Debug.Log($"Load from {Application.persistentDataPath} as {filename}{extension}");
                return data;
            }
            else
            {
                Debug.Log("Can't find file to load in location: " + this.path);
                return null;
            }
        }

        /*internal List<ISavableData> Load()
        {
            
        }*/

        internal ISavableData LoadFrom(string id)
        {
            path = Application.persistentDataPath + "/" + id + extension;

            if (File.Exists(path))
            {
                stream = new FileStream(path, FileMode.Open);
                ISavableData data = binaryFormatter.Deserialize(stream) as ISavableData;
                stream.Close();

                Debug.Log($"Load from {Application.persistentDataPath} as {id}{extension}");
                return data;
            }
            else
            {
                Debug.Log("Can't find file to load in location: " + this.path);
                return null;
            }
        }

        internal Dictionary<string, ISavableData> LoadFrom(List<string> ids)
        {
            var dictionary = new Dictionary<string, ISavableData>();
            
            ids.ForEach(e => dictionary.Add(e, LoadFrom(e)));

            return dictionary;
        }

        internal void AutoLoad()
        {
            
        }

        internal void LoadFromJSON()
        {
            
        }

        internal void LoadFromPrefs()
        {
            
        }
    }
}