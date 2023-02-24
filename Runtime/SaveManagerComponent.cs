using System.Collections.Generic;
using com.maapiid.savesystem;
using System.Linq;
using UnityEngine;

public class SaveManagerComponent : MonoSingleton<SaveManagerComponent>
{
    [ContextMenu("SaveAll")] public void SaveAll() => Save();
    [ContextMenu("LoadAll")] public void LoadAll() => Load();
    
    /*
     * This method looking for all SavableEntity components
     * and saves all ISavable MonoBehaviour scripts data to one binary file.
     */
    public static void Save()
    {
        var state = SaveManager.Load();
        
        CaptureState(state);

        if (state.Count > 0) SaveManager.Save(state);
        else Debug.LogWarning("Cant find anything to save.");
    }
    
    public static void Load() => RestoreState(SaveManager.Load());

    private static void CaptureState(IDictionary<string, object> state)
        => FindObjectsOfType<SavableEntity>().ToList().ForEach(e => state[e.Id] = e.CaptureState());

    private static void RestoreState(IDictionary<string, object> state) =>
        FindObjectsOfType<SavableEntity>().ToList().ForEach(e =>
        {
            if (state.TryGetValue(e.Id, out var value)) e.RestoreState(value);
        });
}