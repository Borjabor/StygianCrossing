using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SmokingRoom : MonoBehaviour
{
    public bool _isActive;

    [SerializeField]
    private bool _isLocked = true;

    [SerializeField]
    private Light[] _SceneLights;

    private AudioSource _as;

    public bool _playSound = false;

    private Collider2D _collider;

    [SerializeField]
    private GlobalVariableListener _listener;

    [SerializeField]
    private string _variableName = "WaltConvo1";

    [SerializeField]
    private GameObject _lockedOverlay;

    private void OnEnable()
    {
        _listener.GlobalVariableChanged += RoomInteraction;
    }

    private void OnDisable()
    {
        _listener.GlobalVariableChanged -= RoomInteraction;
    }

    protected virtual void RoomInteraction(string arg1, object arg2)
    {
        if (arg1 == $"GlobalVariables.{_variableName}" && (bool)arg2)
        {
            _isLocked = false;
            _lockedOverlay.SetActive(false);
            print("Variable" + $"{_variableName}" + "checked");
        }
    }

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
        //     light.enabled = false;
        // }

        _as.Stop();
    }

    private void LockedScene()
    {
        _lockedOverlay.SetActive(true);
        _collider.isTrigger = true;
    }
}