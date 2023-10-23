using System;
using Zenject;

public interface ISaveableComponent
{
    public Type DataType { get; }
    public void PrepareSave();
    public ISaveableData Serialize();
    public void Deserialize(ISaveableData data);
}

public interface ISaveableData
{
}

public abstract class SaveableComponent<T> : ISaveableComponent, IInitializable where T : ISaveableData, new()
{
    public Type DataType => typeof(T);

    protected T _data;
    
    [Inject]
    private ISavesComposer _savesComposer;

    public abstract void PrepareSave();

    public abstract ISaveableData Serialize();

    public abstract void Deserialize(ISaveableData data);

    public void Initialize()
    {
        _savesComposer.AddComponent(this);
    }
}