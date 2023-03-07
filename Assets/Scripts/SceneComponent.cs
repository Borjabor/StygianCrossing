using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneComponent : MonoBehaviour
{

    public bool _isActive;

    private void Start()
    {
        _isActive = false;
    }

    void Update()
    {
        if (_isActive)
        {
            ActiveScene();
        }

        else
        {
            InactiveScene();
        }
    }

    private void ActiveScene()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        print("Scene is active now");
        _isActive = false;
    }
    
    private void InactiveScene()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        // print("Scene is currently inactive");
    }
}
