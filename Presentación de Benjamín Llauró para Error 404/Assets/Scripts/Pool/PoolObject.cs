using UnityEngine;

namespace PoolSystem
{
    public class PoolObject : MonoBehaviour
    {
        public delegate void ObjectRecycle(PoolObject po);
        public event ObjectRecycle onRecycle;
        private Pool pool;

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
}