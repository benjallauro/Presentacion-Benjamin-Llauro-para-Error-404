using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public delegate void ObjectRecycle(PoolObject po);
    public event ObjectRecycle onRecycle;

    private Pool pool;
    private float timerOnLive;
    private const float timeToLive = 10;

    public void SetPool(Pool comingPool)
    {
        pool = comingPool;
    }

    public void Recycle()
    {
        if (onRecycle != null)
            onRecycle(this);

        pool.Recycle(this);
    }
}