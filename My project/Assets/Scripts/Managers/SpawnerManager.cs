using System;
using UnityEngine;

public class SpawnerManager : Manager<SpawnerManager,string,Spawner>
{
    [SerializeField] int gameObjectCount = 25; // Number of gameObjects who can be spawned
    public event Action<int> OnCountChanged;
    public int GameObjectCount => gameObjectCount;

    public bool CanSpawn => gameObjectCount > 0;

    public override void Add(Spawner _value) 
    {
        base.Add(_value);
        _value.OnSpawned += UpdateGameObjectCount; // subscribe to the event on spawn to update the gameObjectCount
    }

    public override void Remove(Spawner _value)
    {
        base.Remove(_value);
        _value.OnSpawned -= UpdateGameObjectCount; // When a gameObject is removed unsubscribe to the event
    }

    void UpdateGameObjectCount() // Called when a gameObject is spawned to update the gameObjectCount
    {
        gameObjectCount--;
        OnCountChanged?.Invoke(gameObjectCount);
    }
}