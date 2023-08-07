using UnityEngine;
using UnityEngine.Events;

public class GlobalEventsCaller : MonoBehaviour
{
    private UnityEvent _globalEvent;
    private bool eventSet = false;

    public void SetGlobalEvent(UnityEvent globalEvent)
    {
        _globalEvent = globalEvent;
        eventSet = true;
    }

    public void CallEvent()
    {
        if (eventSet)
        {
            _globalEvent.Invoke();
        }
        else
            Debug.LogWarning("There is no event set in GlobalEventsCaller");
        
    }
}
