using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace com.maapiid.savesystem.GameDataSystem
{
    internal class SaveManager
    {
        internal void Save(ISavableData data)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/playerData.aru";
            Debug.Log("sciezka -> " +  Application.persistentDataPath);
            FileStream stream = new FileStream(path, FileMode.Create);

            
            
            binaryFormatter.Serialize(stream, data);
            stream.Close();
        }

        internal void AutoSave()
        {
            
        }

        internal void SaveAs()
        {
            
        }

        internal void SaveAsJSON()
        {
            
        }

        internal void SaveToPrefs()
        {
            
        }
    }
}