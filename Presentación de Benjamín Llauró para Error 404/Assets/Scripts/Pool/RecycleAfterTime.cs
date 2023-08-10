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

        #region Unity Methods
        private void Awake()
        {
            timer = new Timer();
            timer.SetTimer(secondsBeforeRecycle);
        }
        private void Update()
        {
            if (timer.Update(Time.deltaTime))
            {
                timer.StopAndReset();
                recycleEvent.Invoke();
                GetComponent<PoolObject>().Recycle();
            }
        }
        #endregion

        #region Public Methods
        public void StartTimer()
        {            
            timer.Start();
        }
        public void ForceRecycle()
        {
            timer.StopAndReset();
            GetComponent<PoolObject>().Recycle();
        }
        #endregion
    }
}