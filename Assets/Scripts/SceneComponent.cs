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
        Transform overlayTransform = transform.GetChild(0);
        overlayTransform.GetComponent<Renderer>().enabled = false;
        print("This scene is active now");
    }
    
    private void InactiveScene()
    {
        Transform overlayTransform = transform.GetChild(0);
        overlayTransform.GetComponent<Renderer>().enabled = true;
    }
}
