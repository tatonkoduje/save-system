using System.Collections.Generic;

namespace com.maapiid.savesystem
{
    public class SaveManager : Singleton<SaveManager>
    {
        public static void Save(IDictionary<string, object> state)
        {
            FileManager.SaveFile(state);
        }

        public static IDictionary<string, object> Load()
        {
            return FileManager.LoadFile();
        }
    }
}