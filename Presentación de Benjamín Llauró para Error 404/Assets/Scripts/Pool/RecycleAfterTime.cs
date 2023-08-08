using System;
using Tools;
using UnityEngine;
using UnityEngine.Events;

namespace PoolSystem
{
    public class RecycleAfterTime : MonoBehaviour
    {
        [SerializeField] private float secondsBeforeRecycle;
        private Timer timer;
        [Serializable] public class CustomEvent : UnityEvent { }
        public CustomEvent recycleEvent;
        private void Awake()
        {
            timer = new Timer();
            timer.SetTimer(secondsBeforeRecycle);
        }
        public void StartTimer()
        {            
            timer.Start();
        }
        public void ForceRecycle()
        {
            timer.StopAndReset();
            GetComponent<PoolObject>().Recycle();
        }
        
        private void Update()
        {
            if(timer.Update(Time.deltaTime))
            {
                timer.StopAndReset();
                recycleEvent.Invoke();
                GetComponent<PoolObject>().Recycle();
            }
        }
    }
}