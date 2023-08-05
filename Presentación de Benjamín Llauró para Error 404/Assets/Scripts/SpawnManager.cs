using Tools;
using PoolSystem;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Pool objectPool1;
    [SerializeField] private RandomAreaPositioner randomAreaPositioner;
    private Timer timer;

    private void Start()
    {
        timer = new Timer();
        timer.Start();
        timer.SetTimer(timeBetweenSpawns);
    }
    private void Update()
    {
        if(timer.Update(Time.deltaTime))
        {
            GameObject pooledObject = objectPool1.GetPooledObject().gameObject;
            pooledObject.transform.position = randomAreaPositioner.RandomizePosition(pooledObject.transform.position);
            pooledObject.GetComponent<RecycleAfterTime>().StartTimer();
            timer.StopAndReset();
            timer.Start();
        }
    }
}