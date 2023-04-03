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

    private Vector3 _targetPosition;

    private Camera _cam;

    private void Start()
    {
        _cam = GetComponent<Camera>();
    }

    void Update()
    {
        //PanAndZoom();

        ZoomInToCharacter();

        FollowPlayer();
    }

    private void PanAndZoom()
    {
        //pan
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - dragOrigin;
            transform.position -= delta * Time.deltaTime * moveSpeed / transform.localScale.x;
            dragOrigin = Input.mousePosition;
        }

        //zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float zoomAmount = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
        Camera.main.orthographicSize = zoomAmount;
    }


    private void ZoomInToCharacter()
    {

        if (_gameState.Value == States.DIALOGUE)
        {
            
            // _targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5f);
            // transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);

            // var newValue = Mathf.MoveTowards(5f, 3.8f, step);
            _cam.orthographicSize = 3.8f;
            _inDialogue = true;
        }

        if (_gameState.Value == States.NORMAL)
        {
            // if (_inDialogue)
            // {
                // var newValue = Mathf.MoveTowards(3.8f, 5f, step);
                _cam.orthographicSize = 5f;
            // }
        }
    }

    private void FollowPlayer()
    {
        var position = _playerTransform.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}