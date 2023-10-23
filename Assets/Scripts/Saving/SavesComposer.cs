using System;
using System.Collections.Generic;
using Zenject;

public interface ISavesComposer
{
    public List<ISaveableComponent> Components { get; }
    
    public void AddComponent(ISaveableComponent component);

    public ISaveableComponent GetComponent(Type saveableDataType);

    public void PrepareComponents();
}

public class SavesComposer : ISavesComposer
{
    public List<ISaveableComponent> Components => _components;
    
    private readonly List<ISaveableComponent> _components = new List<ISaveableComponent>();
    
    private readonly Dictionary<Type, ISaveableComponent> _componentsData = new Dictionary<Type, ISaveableComponent>();
    
    private IEnumerable<ISaveableData> _dataList;
    private DiContainer _container;

    public void AddComponent(ISaveableComponent component)
    {
        _components.Add(component);
        _componentsData.Add(component.DataType, component);
    }

    public ISaveableComponent GetComponent(Type saveableDataType)
    {
        return _componentsData.ContainsKey(saveableDataType) ? _componentsData[saveableDataType] : null;
    }

    public void PrepareComponents()
    {
        foreach (var component in _components)
        {
            component.PrepareSave();
        }
    }
}