using System;
using UnityEngine;
using UnityEngine.Events;

public class SelectObject : MonoBehaviour
{
    Vector3 mousePosition;
    [Serializable] public class CustomEvent : UnityEvent { }
    public CustomEvent customEvent;
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        customEvent.Invoke();
        //mousePosition = Input.mousePosition - GetMousePos(); 
    }
}