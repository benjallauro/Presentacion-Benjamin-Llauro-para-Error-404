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
    [SerializeField] private int objectsGrantedForClickingTarget;
    [SerializeField] private int targetRewardObjectPoolNumber;
    private Timer timer;

    [Serializable] public class CustomEvent : UnityEvent { }
    public CustomEvent[] globalEventForObjects;
    public CustomEvent[] globalOutliveEventForObjects; //The event that should be called when the object recycles itself by outliving it's time limit.
    private bool on;
    private int _poolsAmount;
    private int _currentPool;

    private bool _inTargetEffect = false;
    int _currentTargetObjectsDropped = 0;


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
            int poolToSelect;
            if (_inTargetEffect)
            {
                poolToSelect = targetRewardObjectPoolNumber;
                _currentTargetObjectsDropped++;
            }
            else
                poolToSelect = _currentPool;
            GameObject pooledObject = objectPools[poolToSelect].GetPooledObject().gameObject;
            pooledObject.transform.position = randomAreaPositioner.RandomizePosition(pooledObject.transform.position);
            GlobalEventsCaller globalEventsCaller = pooledObject.GetComponent<GlobalEventsCaller>();
            globalEventsCaller.SetGlobalEvent(globalEventForObjects[poolToSelect]);
            globalEventsCaller.SetGlobalEvent2(globalOutliveEventForObjects[poolToSelect]);
            pooledObject.GetComponent<RecycleAfterTime>().StartTimer();
            timer.StopAndReset();
            timer.Start();
            if(!_inTargetEffect)
                _currentPool++;
            if (_currentTargetObjectsDropped >= objectsGrantedForClickingTarget)
            {
                _inTargetEffect = false;
                _currentTargetObjectsDropped = 0;
            }
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
    public void EnableTargetEffect()
    {
        _inTargetEffect = true;
        _currentTargetObjectsDropped = 0;
    }
}