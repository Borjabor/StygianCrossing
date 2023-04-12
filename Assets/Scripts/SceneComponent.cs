using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(AudioSource))]
public class SceneComponent : MonoBehaviour
{
    public bool _isActive;

    [SerializeField]
    private bool _isLocked = false;

    [SerializeField]
    private Light2D[] _SceneLights;

    private AudioSource _as;

    public bool _playSound = false;

    private Collider2D _collider;

    private void Start()
    {
        _isActive = false;
        _as = GetComponent<AudioSource>();
        _collider = GetComponent<Collider2D>();
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

        foreach (var light in _SceneLights)
        {
            light.enabled = true;
        }

        if (_playSound)
        {
            _as.Play();
            _playSound = false;
        }
        //print("This scene is active now");
    }

    private void InactiveScene()
    {
        Transform overlayTransform = transform.GetChild(0);
        overlayTransform.GetComponent<Renderer>().enabled = true;

        // foreach (var light in _SceneLights)
        // {
        //     //light.GetComponent<LightFlicker>().Toggle();
        //     light.enabled = false;
        // }

        _as.Stop();
    }

    private void LockedScene()
    {
        _collider.isTrigger = true;
    }
}