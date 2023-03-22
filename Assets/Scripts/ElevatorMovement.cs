using System;
using System.Collections;
using System.Collections.Generic;
using Articy.Unity.Interfaces;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField]
    private GlobalVariableListener _listener;

    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private Vector3 _topFloorPosition;

    [SerializeField]
    private Vector3 _baseFloorPosition;

    [SerializeField]
    private Vector3 _base2FloorPosition;

    [SerializeField]
    private float _moveSpeed = 1f;

    private int _currentFloor = 1;

    private AudioSource _as;
    
    private enum FloorNumber
    {
        First,
        Second,
        Third
    }

    private FloorNumber _floor;

    private void OnEnable()
    {
        _listener.GlobalVariableChanged += FloorFirst;
        _listener.GlobalVariableChanged += FloorSecond;
        _listener.GlobalVariableChanged += FloorThird;
    }

    private void OnDisable()
    {
        _listener.GlobalVariableChanged -= FloorFirst;
        _listener.GlobalVariableChanged -= FloorSecond;
        _listener.GlobalVariableChanged -= FloorThird;
    }

    private void Start()
    {
        _floor = FloorNumber.First;
        _as = GetComponent<AudioSource>();
        _currentFloor = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void FloorFirst(string arg1, object arg2)
    {
        if (arg1 == "GameState.ElevatorLevel" && (int)arg2 == 0)
        {
            _floor = FloorNumber.First;
        }
    }

    private void FloorSecond(string arg1, object arg2)
    {
        if (arg1 == "GameState.ElevatorLevel" && (int)arg2 == 1)
        {
            _floor = FloorNumber.Second;
        }
    }

    private void FloorThird(string arg1, object arg2)
    {
        if (arg1 == "GameState.ElevatorLevel" && (int)arg2 == 2)
        {
            _floor = FloorNumber.Third;
        }
    }

    private void Movement()
    {
        float step = _moveSpeed * Time.deltaTime;

        if (_floor == FloorNumber.First) //variable code comes here
        {
            if (_currentFloor != 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, _topFloorPosition, step);
                if (transform.position == _topFloorPosition)
                {
                    _currentFloor = 1;
                    
                }
            }
        }

        if (_floor == FloorNumber.Second) //variable code comes here
        {
            if (_currentFloor != 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, _baseFloorPosition, step);
                if (transform.position == _baseFloorPosition)
                {
                    _currentFloor = 2;
                }
            }
        }

        if (_floor == FloorNumber.Third) //variable code comes here
        {
            if (_currentFloor != 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, _base2FloorPosition, step);
                if (transform.position == _base2FloorPosition)
                {
                    _currentFloor = 3;
                }
            }
        }
    }
}