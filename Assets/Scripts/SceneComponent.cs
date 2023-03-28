using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SceneComponent : MonoBehaviour
{

    public bool _isActive;
    
    [SerializeField]
    private bool _isLocked = false;

    [SerializeField]
    private Light[] _SceneLights;

    private AudioSource _as;

    private void Start()
    {
        _isActive = false;
        _as = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!_isLocked)
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

        else
        {
            LockedScene();
        }
    }

    private void ActiveScene()
    {
        Transform overlayTransform = transform.GetChild(0);
        overlayTransform.GetComponent<Renderer>().enabled = false;
        _as.Play();
        //print("This scene is active now");
    }
    
    private void InactiveScene()
    {
        Transform overlayTransform = transform.GetChild(0);
        overlayTransform.GetComponent<Renderer>().enabled = true;
        _as.Stop();
    }

    private void LockedScene()
    {
        
    }
}
