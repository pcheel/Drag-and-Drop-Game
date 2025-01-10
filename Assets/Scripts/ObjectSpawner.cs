using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner
{
    private DragbleObjectsConfig _config;
    private ObjectFactory _factory;
    private List<DragblePresenter> _dragblePresenters;

    public ObjectSpawner(ObjectFactory factory, DragbleObjectsConfig config)
    {
        _factory = factory;
        _config = config;
        _dragblePresenters = new List<DragblePresenter>();
    }

    public void SpawnObjects()
    {
        foreach (var config in _config.dragbleObjects)
        {
            _dragblePresenters.Add(_factory.CreateObject(config));
        }
    }
}
