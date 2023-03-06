using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _targetPosition;

    [SerializeField]
    private PlayerState _playerState;
    
    private bool _isMoving;

    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(MyTags.LevelNavigator))
        {
            _isMoving = false;
            _playerState.Value = PlayerStates.IDLE;
        }
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition.y = transform.position.y;
            _isMoving = true;
            _playerState.Value = PlayerStates.WALKING;
            print(_playerState.Value);
        }

        if (_isMoving)
        {
            float step = _moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);

            if (transform.position == (Vector3)_targetPosition)
            {
                _isMoving = false;
                _playerState.Value = PlayerStates.IDLE;
                print(_playerState.Value);
            }
        }
    }
    
}