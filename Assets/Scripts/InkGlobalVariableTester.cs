using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkGlobalVariableTester : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        string colorChosen = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("color_choice"))
            .value;

        switch (colorChosen)
        {
            case "Red":
                _renderer.material.color = Color.red;
                break;
            case "Green":
                _renderer.material.color = Color.green;
                break;
            case "Blue":
                _renderer.material.color = Color.blue;
                break;
            default:
                break;
            
        }
    }
}
