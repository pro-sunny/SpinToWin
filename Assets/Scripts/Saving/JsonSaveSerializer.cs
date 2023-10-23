using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class JsonSaveSerializer : ISaveSerializer
{
    private ISavesComposer _savesComposer;
    
    public JsonSaveSerializer(ISavesComposer savesComposer)
    {
        _savesComposer = savesComposer;
    }
    
    public string SerializeSave()
    {
        var saveData = CreateSaveData();
        
        var json = JsonConvert.SerializeObject(saveData, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });

        return json;
    }

    public void DeserializeSave(string text)
    {
        SaveData obj = JsonConvert.DeserializeObject<SaveData>(text, new JsonSerializerSettings 
        { 
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore,
        });
        
        foreach (var saveData in obj.Components)
        {
            Type dataType = saveData.GetType();
            var component = _savesComposer.GetComponent(dataType);
            component?.Deserialize(saveData);
        }
    }

    private SaveData CreateSaveData()
    {
        var data = new SaveData();
        data.Header = new SaveHeader()
        {
            DateTime = DateTime.Now.ToString(),
            Version = Application.version
        };
        data.Components = _savesComposer.Components.Select( c => c.Serialize() ).ToList();
        return data;
    }
}

public class SaveData
{
    public SaveHeader Header;
    public List<ISaveableData> Components;
}

public class SaveHeader
{
    public string DateTime;
    public string Version;
}
