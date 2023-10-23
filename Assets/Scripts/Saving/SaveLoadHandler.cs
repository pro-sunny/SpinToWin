using System.IO;
using UnityEngine;

public interface ISaveLoadHandler
{
    public void Save();
    public void Load();
}

public class SaveLoadHandler : ISaveLoadHandler
{
    private readonly string filename = Path.Combine(Application.persistentDataPath, "save.dat");
    
    private ISaveSerializer _saveSerializer;
    private IIOWorker _ioWorker;

    public SaveLoadHandler(ISaveSerializer saveSerializer, IIOWorker ioWorker)
    {
        _saveSerializer = saveSerializer;
        _ioWorker = ioWorker;
    }
    
    public void Save()
    {
        var dataString = _saveSerializer.SerializeSave();
        _ioWorker.Write(dataString, filename);
    }

    public void Load()
    {
        var dataString = _ioWorker.Read(filename);
        _saveSerializer.DeserializeSave(dataString);
    }
}