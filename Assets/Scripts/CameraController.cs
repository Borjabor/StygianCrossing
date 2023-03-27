using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private float zoomSpeed = 5f; 
    [SerializeField] private float minZoom = 1f; 
    [SerializeField] private float maxZoom = 5f;

    [Space, Header("Game State")]
    [SerializeField]
    private GameState _gameState;

    [SerializeField]
    private Transform _playerTransform;

    private Vector3 dragOrigin;

    private bool _inDialogue = false;
    private float _moveSpeed = 1f;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
    }

    void Update()
    {
        //PanAndZoom();
        MoveCameraToCenter();
        
        if (!_inDialogue)
        {
            FollowPlayer();  
        }
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

    private void MoveCameraToCenter()
    {
        float step = _moveSpeed * Time.deltaTime;
        
        
        if (_gameState.Value == States.DIALOGUE)
        {
            _inDialogue = true;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
        }
        
        if (_gameState.Value == States.NORMAL)
        {
            _inDialogue = false;
        }
    }

    private void FollowPlayer()
    {
        var position = _playerTransform.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
