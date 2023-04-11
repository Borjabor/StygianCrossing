using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;

    private Vector2 _targetPosition;

    [SerializeField]
    private PlayerState _playerState;

    [SerializeField]
    private GameState _gameState;


    private bool _isMoving;


    // [SerializeField]
    // private GameObject _sprite;

    public float spriteScale = 0.5f;

    private Camera mainCamera;

    [Space, Header("Animation")]
    private Animator _anim;

    private Vector3 prevPosition;

    [Space, Header("Sound")]
    
    private AudioSource _as;
    

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
        mainCamera = Camera.main;
        prevPosition = transform.position;
    }

    void Update()
    {
        AnimationMovement();
        if (_gameState.Value is States.PAUSED or States.DIALOGUE) return;
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

        if (other.CompareTag(MyTags.NotAccessible))
        {
            _isMoving = false;
            _playerState.Value = PlayerStates.IDLE;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(MyTags.NotAccessible))
        {
            _isMoving = false;
            _playerState.Value = PlayerStates.IDLE;
        }
    }

    private void Movement()
    {
        
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButton(0))
        {
            _targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition.y = transform.position.y;
            _isMoving = true;
            _playerState.Value = PlayerStates.WALKING;
            //print(_playerState.Value);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * (Time.deltaTime * _moveSpeed);
            _playerState.Value = PlayerStates.WALKING;
            if (!_as.isPlaying)
            {
                _as.Play();   
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (Time.deltaTime * _moveSpeed);
            _playerState.Value = PlayerStates.WALKING;
            if (!_as.isPlaying)
            {
                _as.Play();   
            }
        }

        if (_isMoving && _playerState.Value == PlayerStates.WALKING)
        {
            float step = _moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);
            if (!_as.isPlaying)
            {
                _as.Play();   
            }

            if (transform.position == (Vector3)_targetPosition)
            {
                _isMoving = false;
                _playerState.Value = PlayerStates.IDLE;
                _as.Stop();
                //print(_playerState.Value);
            }
        }
    }

    private void SpawnSprite()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = GetClickPosition();

            // _sprite.transform.position = clickPosition;
            // _sprite.transform.localScale = new Vector3(spriteScale, spriteScale, spriteScale);
            // Instantiate(_sprite, clickPosition, Quaternion.identity);
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

    private void AnimationMovement()
    {
        Vector3 currentPosition = transform.position;
        Vector3 velocity = (currentPosition - prevPosition) / Time.deltaTime;

        if (_gameState.Value == States.DIALOGUE)
        {
            _anim.SetBool("isRunning", false);
        }
        
        else
        {
            if (velocity.magnitude > 0.5f && _gameState.Value != States.DIALOGUE)
            {
                _anim.SetBool("isRunning", true);
            }

            else
            {
                _anim.SetBool("isRunning", false);
            }

            if (currentPosition.x > prevPosition.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (currentPosition.x < prevPosition.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        prevPosition = currentPosition;
    }
}