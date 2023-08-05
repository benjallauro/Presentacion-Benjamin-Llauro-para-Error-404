using System.Collections.Generic;
using UnityEngine;

namespace PoolSystem
{
    public class Pool : MonoBehaviour
    {
        public GameObject prefab;
        public int number; //The maximum number of times that the object will appear at the same time
        private List<PoolObject> poolList = new List<PoolObject>();
        int recycledObjectsNumber = 0;
        void Awake()
        {
            for (int i = 0; i < number; i++)
            {
                PoolObject po = CreateObject();
                poolList.Add(po);
            }
        }
        public PoolObject GetPooledObject()
        {
            if (poolList.Count > 0)
            {
                PoolObject po = poolList[0];
                po.gameObject.SetActive(true);
                poolList.RemoveAt(0);
                return po;
            }
            else
            {
                PoolObject po = CreateObject();
                po.gameObject.SetActive(true);
                // Debug.LogWarning("Se creo un objeto en tiempo de ejecucion (pool)");
                return po;
            }
        }
        public void Recycle(PoolObject po)
        {
            poolList.Add(po);
            po.gameObject.SetActive(false);
            recycledObjectsNumber++;
        }
        public int GetRecycledObjectsNumber()
        {
            return recycledObjectsNumber;
        }
        public void ResetRecycledObjectsNumber()
        {
            recycledObjectsNumber = 0;
        }
        public int GetObjectCount() // devuelve la cantidad de objetos activos
        {
            return poolList.Count;
        }
        private PoolObject CreateObject()
        {
            GameObject go = Instantiate(prefab);
            PoolObject po = go.AddComponent<PoolObject>();
            po.SetPool(this);
            go.SetActive(false);
            return po;
        }
    }

}