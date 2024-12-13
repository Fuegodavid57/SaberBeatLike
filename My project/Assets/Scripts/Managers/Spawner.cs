using System;
using UnityEngine;

public class Spawner : MonoBehaviour, IManageable<string>
{
    public event Action OnSpawned;
    public event Action OnTimerComplete;
    [SerializeField] string id = "Spawner";
    [SerializeField] bool canSpawn = true;
    [SerializeField] float currentTime = 0f, maxTime = 0f;
    [SerializeField] float minRange = 0.5f, maxRange = 1.5f;
    public string ID => id;

    public bool IsValidItem => throw new System.NotImplementedException();

    void Start()
    {
        Init();
    }

    void Update()
    {
        if(!canSpawn) return;
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            currentTime = 0f;
            OnTimerComplete?.Invoke();
        }
    }

    void Init()
    {
        Register();
        UpdateMaxTime();
        OnTimerComplete += UpdateMaxTime;
        OnTimerComplete += Spawn;
    }

    float GetRandomMaxTime()
    {
        return UnityEngine.Random.Range(minRange, maxRange);
    }

    void UpdateMaxTime()
    {
        maxTime = GetRandomMaxTime();
    }

    public void SetId(string _key)
    {
        id = _key;
    }

    public void Enable()
    {
        canSpawn = true;
    }

    public void Disable()
    {
        canSpawn = false;
    }
    void Register() => SpawnerManager.Instance.Add(this);

    void Spawn()
    {
        if(!SpawnerManager.Instance.CanSpawn)
        {
            canSpawn = false;
            return;
        }
        OnSpawned?.Invoke();
    }
}