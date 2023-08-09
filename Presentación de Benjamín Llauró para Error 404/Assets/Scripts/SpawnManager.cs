using Tools;
using PoolSystem;
using UnityEngine;
using System;
using UnityEngine.Events;
using GameManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float minTimeBetweenSpawns;
    [SerializeField] private float maxTimeBetweenSpawns;
    [SerializeField] private Pool[] objectPools;
    [SerializeField] private RandomAreaPositioner randomAreaPositioner;
    [SerializeField] private int objectsGrantedForClickingTarget;
    [SerializeField] private int targetRewardObjectPoolNumber;
    private Timer timer;
    private Difficulty _difficulty;

    [Serializable] public class CustomEvent : UnityEvent { }
    public CustomEvent[] globalEventForObjects;
    public CustomEvent[] globalOutliveEventForObjects; //The event that should be called when the object recycles itself by outliving it's time limit.

    private bool _inTargetEffect = false;
    int _currentTargetObjectsDropped = 0;


    private void Awake()
    {
        timer = new Timer();
    }
    public void StartSpawning()
    {
        timer.SetTimer(UnityEngine.Random.Range(_difficulty.minimumTimeBetweenSpawns, _difficulty.maximumTimeBetweenSpawns));
        timer.Start();
    }
    private void Update()
    {
        if(timer.Update(Time.deltaTime) && objectPools.Length > 0)
        {
            int poolToSelect;
            if (_inTargetEffect)
            {
                poolToSelect = targetRewardObjectPoolNumber;
                _currentTargetObjectsDropped++;
            }
            else
                poolToSelect = UnityEngine.Random.Range(0, objectPools.Length);
            GameObject pooledObject = objectPools[poolToSelect].GetPooledObject().gameObject;
            pooledObject.transform.position = randomAreaPositioner.RandomizePosition(pooledObject.transform.position);
            GlobalEventsCaller globalEventsCaller = pooledObject.GetComponent<GlobalEventsCaller>();
            globalEventsCaller.SetGlobalEvent(globalEventForObjects[poolToSelect]);
            globalEventsCaller.SetGlobalEvent2(globalOutliveEventForObjects[poolToSelect]);
            pooledObject.GetComponent<RecycleAfterTime>().StartTimer();
            timer.StopAndReset();
            timer.SetTimer(UnityEngine.Random.Range(_difficulty.minimumTimeBetweenSpawns, _difficulty.maximumTimeBetweenSpawns));
            timer.Start();
            if (_currentTargetObjectsDropped >= objectsGrantedForClickingTarget)
            {
                _inTargetEffect = false;
                _currentTargetObjectsDropped = 0;
            }
        }
    }
    public void SetDifficultyLevel(Difficulty difficulty)
    {
        _difficulty = difficulty;
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