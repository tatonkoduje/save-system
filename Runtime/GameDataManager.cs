using com.maapiid.savesystem.GameDataSystem;

// TODO: 1a. prepare data classes and save all
// TODO: 1b. then load all data and match manually
// TODO: 1c. save to refs and json as well
// TODO: 1d. keep history of saves
    
// TODO: 2a. create some mapper or use some from net ?
// TODO: 2b puy bunch of MB classes and map to data objects in both way - load and save
    
    
    
// Options for game developer:
// - seve(one data file) default file name (id)
// - saveTo(one data file, file name)
// - save(bunch of data classes) default file name
// - saveTo(bunch of data classes, file id) default file id - file id have to be set in settings
// - load() load default singe data file name
// - loadFrom(file name) load one data class from specific file name
// - load() load bunch of data classes
// - loadFrom(file id) load bunch of classes from file id
// - MessageHandler between scenes
    
// - SaveAs(data, id, description)
// - LoadAs(id)
    
// - saveToPrefs(), saveToJson(), loadFromPRefs(), loadFromJson()
// - some settings - keep history
    
public class GameDataManager
{
    public static ISavableData Load()
    {
        LoadManager lM = new LoadManager();
        return lM.Load();
            
    }

    public static void Save(ISavableData data)
    {
        SaveManager sM = new SaveManager();
        sM.Save(data);
    }
}