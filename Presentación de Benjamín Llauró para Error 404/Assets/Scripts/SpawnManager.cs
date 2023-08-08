using Tools;
using PoolSystem;
using UnityEngine;
using System;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Pool[] objectPools;
    [SerializeField] private RandomAreaPositioner randomAreaPositioner;
    private Timer timer;

    [Serializable] public class CustomEvent : UnityEvent { }
    public CustomEvent[] globalEventForObjects;
    private bool on;
    private int _poolsAmount;
    private int _currentPool;

    private void Start()
    {
        timer = new Timer();
        timer.Start();
        timer.SetTimer(timeBetweenSpawns);
        _poolsAmount = objectPools.Length;
        _currentPool = 0;
    }
    private void Update()
    {
        if(_currentPool >= _poolsAmount)
            _currentPool = 0; 
        if(timer.Update(Time.deltaTime) && objectPools.Length > 0)
        {
            GameObject pooledObject = objectPools[_currentPool].GetPooledObject().gameObject;
            pooledObject.transform.position = randomAreaPositioner.RandomizePosition(pooledObject.transform.position);
            pooledObject.GetComponent<GlobalEventsCaller>().SetGlobalEvent(globalEventForObjects[_currentPool]);
            pooledObject.GetComponent<RecycleAfterTime>().StartTimer();
            timer.StopAndReset();
            timer.Start();
            _currentPool++;
        }
    }
    public void StartSpawning()
    {
        timer.Start();
        timer.SetTimer(timeBetweenSpawns);
    }
    public void StopSpawning()
    {
        timer.StopAndReset();
    }
}