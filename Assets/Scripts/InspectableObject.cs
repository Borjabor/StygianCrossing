using System;
using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using UnityEngine;

public class InspectableObject : MonoBehaviour
{

    [SerializeField]
    private Texture2D _magnifyCursor;
    
    [SerializeField]
    private GlobalVariableListener _listener;

    [SerializeField]
    private string _name;

    private bool _canBeClicked = false;

    private void OnEnable()
    {
        _listener.GlobalVariableChanged += ObjectInteraction;
    }
    
    private void OnDisable()
    {
        _listener.GlobalVariableChanged -= ObjectInteraction;
    }

    protected virtual void ObjectInteraction(string arg1, object arg2)
    {
        if (arg1 == $"Investigation.{_name}" && (bool)arg2)
        {
            _canBeClicked = true;
        }
    }

    private void OnMouseDown()
    {
        if (_canBeClicked == true)
        {
            print($"picking up {_name}");
            gameObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(_magnifyCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
