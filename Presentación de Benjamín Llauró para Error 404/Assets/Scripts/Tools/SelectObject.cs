using System;
using UnityEngine;
using UnityEngine.Events;

public class SelectObject : MonoBehaviour
{
    [SerializeField] private int clicksRequired = 1;
    private int _clicksAmount = 0;
    [Serializable] public class CustomEvent : UnityEvent { }
    public CustomEvent customEvent;

    public void ResetClicks()
    {
        _clicksAmount = 0;
    }

    private void OnMouseDown()
    {
        _clicksAmount++;
        if(_clicksAmount >= clicksRequired)
            customEvent.Invoke();
    }
}