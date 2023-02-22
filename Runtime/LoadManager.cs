using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace com.maapiid.savesystem.GameDataSystem
{
    internal class LoadManager
    {
        internal ISavableData Load()
        {
            string path = Application.persistentDataPath + "/playerData.aru";

            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                ISavableData data = binaryFormatter.Deserialize(stream) as ISavableData;
                stream.Close();

                return data;
            }
            else
            {
                Debug.Log("Plik z savem nie istnieje");
                return null;
            }
        }

        internal void AutoLoad()
        {
            
        }

        internal void LoadFrom()
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