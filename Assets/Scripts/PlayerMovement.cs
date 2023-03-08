using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _targetPosition;

    [SerializeField]
    private PlayerState _playerState;
    
    private bool _isMoving;


    [SerializeField]
    private GameObject _sprite;
  
    public float spriteScale = 0.5f;
    
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Movement();
        SpawnSprite();
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
            _targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
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
    
    private void SpawnSprite()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 clickPosition = GetClickPosition();
            
            _sprite.transform.position = clickPosition;
            _sprite.transform.localScale = new Vector3(spriteScale, spriteScale, spriteScale);
            Instantiate(_sprite, clickPosition, Quaternion.identity);
        }
    }

    private Vector3 GetClickPosition()
    {
        Vector3 clickPosition = Vector3.zero;
        
        if (Input.touchCount > 0)
        {
            clickPosition = mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        clickPosition.z = 0;

        return clickPosition;
    }

}