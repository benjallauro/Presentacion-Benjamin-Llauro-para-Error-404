using Tools;
using UnityEngine;
namespace PoolSystem
{
    public class RecycleAfterTime : MonoBehaviour
    {
        [SerializeField] private float secondsBeforeRecycle;
        private Timer timer;
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
                GetComponent<PoolObject>().Recycle();
            }
        }
    }
}
