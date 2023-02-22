using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Linq;

namespace com.maapiid.savesystem
{
    internal class SaveManager
    {
        private BinaryFormatter binaryFormatter;
        private FileStream stream;
        private string path;
        private string filename;
        private string extension;

        internal SaveManager()
        {
            this.binaryFormatter = new BinaryFormatter();
            this.path = "/";
            this.filename = "gamedata";
            this.extension = ".aru";
        }

        private void Save()
        {
            
        }
        
        /**
         * saved ISavableData class to file with default name. Always overwrite this file
         */
        internal void Save(ISavableData data)
        {
            path = Application.persistentDataPath + "/" + filename + extension;

            stream = new FileStream(path, FileMode.Create);
            binaryFormatter.Serialize(stream, data);
            stream.Close();
            
            Debug.Log($"Saved in {Application.persistentDataPath} as {filename}{extension}");
        }

        /**
         * save data to file with name ID and extension .aru. Always overwrite file.
         */
        internal void SaveTo(ISavableData data, string id)
        {
            path = Application.persistentDataPath + "/" + id + extension;
            stream = new FileStream(path, FileMode.Create);
            binaryFormatter.Serialize(stream, data);
            stream.Close();
            
            Debug.Log($"Saved in {Application.persistentDataPath} as {id}{extension}");
        }

        internal void Save(List<ISavableData> datas)
        {
            datas.ForEach(Save); // to nei zadzaila bo zastapi caly zcas ten sam plik - tu niech zapisuje do folderu a pozniej laduje wszystkie pliki z folderu
        }
        
        internal void SaveTo(Dictionary<string, ISavableData> datas)
        {
            datas.ToList().ForEach(pair => SaveTo(pair.Value, pair.Key));
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