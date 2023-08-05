using Tools;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Pool objectPool1;
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
            objectPool1.GetPooledObject();
            timer.StopAndReset();
            timer.Start();
        }
    }
}