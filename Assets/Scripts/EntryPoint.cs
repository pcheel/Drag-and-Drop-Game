using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private ObjectFactory _factory;
    [SerializeField] private DragbleObjectsConfig _config;

    private ObjectSpawner _spawner;

    private void Awake()
    {
        _spawner = new ObjectSpawner(_factory, _config);
    }
    private void Start()
    {
        _spawner.SpawnObjects();
    }
}
