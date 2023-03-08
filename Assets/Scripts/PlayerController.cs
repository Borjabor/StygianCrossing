using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputsActions _playerInputsActions;
    private InputAction _pointerPositionInputAction;
    private Camera _mainCamera;
    private Vector2 _pointerPosition;
    private IInteractable _previousInteractable;
    [SerializeField] private GameState _gameState;
    

    private void Awake()
    {
        _playerInputsActions = new PlayerInputsActions();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        
        _pointerPositionInputAction = _playerInputsActions.Player.PointerPosition;
        _pointerPositionInputAction.Enable();
        _playerInputsActions.Player.Click.performed += OnClick;
        _playerInputsActions.Player.Click.Enable();
    }

    private void OnDisable()
    {
        _pointerPositionInputAction.Disable();
        _playerInputsActions.Player.Click.performed -= OnClick;
        _playerInputsActions.Player.Click.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        //Debug.Log($"click");
        Ray ray = _mainCamera.ScreenPointToRay(_pointerPositionInputAction.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out var hit) && hit.collider.GetComponent<IInteractable>() != null)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }

    private void Update()
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        Ray ray = _mainCamera.ScreenPointToRay(_pointerPositionInputAction.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out var hit))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != _previousInteractable)
            {
                interactable?.ShowPrompt();
                _previousInteractable?.HidePrompt();
                _previousInteractable = interactable;
            }
        }
        
    }
}
