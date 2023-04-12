using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float zoomSpeed = 5f;

    [SerializeField]
    private float minZoom = 1f;

    [SerializeField]
    private float maxZoom = 5f;

    [Space, Header("Game State")]
    [SerializeField]
    private GameState _gameState;

    [SerializeField]
    private Transform _playerTransform;

    private Vector3 dragOrigin;

    private bool _inDialogue = false;
    private bool _newPosition = false;

    int value = 0;

    private float _moveSpeed = 7f;

    [SerializeField]
    private Transform _targetPosition;

    private Camera _cam;

    private void Start()
    {
        _cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (_gameState.Value == States.DIALOGUE)
        {
            _inDialogue = true;
        }

        if (_gameState.Value == States.NORMAL)
        {
            _inDialogue = false;
        }
        
        if (_inDialogue)
        {
            MoveCameraToTheRight();
        }

        else
        {
            FollowPlayer();
        }
    }


    private void MoveCameraToTheRight()
    {
        float step = _moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, 1.5f * Time.deltaTime);
        
        
    }

    private void FollowPlayer()
    {
        var position = _playerTransform.position;
        transform.position = new Vector3(position.x, position.y + 1.59f, transform.position.z);
    }
}