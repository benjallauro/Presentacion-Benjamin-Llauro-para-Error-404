using UnityEngine;
using UnityEngine.Events;

namespace Tools
{
    public class GlobalEventsCaller : MonoBehaviour
    {
        private UnityEvent _globalEvent;
        private UnityEvent _globalEvent2;
        private bool eventSet = false;
        private bool eventSet2 = false;

        #region Set Global Events
        public void SetGlobalEvent(UnityEvent globalEvent)
        {
            _globalEvent = globalEvent;
            eventSet = true;
        }
        public void SetGlobalEvent2(UnityEvent globalEvent2)
        {
            _globalEvent2 = globalEvent2;
            eventSet2 = true;
        }
        #endregion

        #region Call Events
        public void CallEvent()
        {
            if (eventSet)
                _globalEvent.Invoke();
            else
                Debug.LogWarning("Missing event set in GlobalEventsCaller");
        }
        public void CallEvent2()
        {
            if (eventSet2)
                _globalEvent2.Invoke();
            else
                Debug.LogWarning("Missing event set in GlobalEventsCaller");    
        }
        #endregion
    }
}