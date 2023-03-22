using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
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
        
        //Raycast to objects to check if they are interactable
        Ray ray = _mainCamera.ScreenPointToRay(_pointerPositionInputAction.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out var hit) && hit.collider.GetComponent<IInteractable>() != null)
        {
            // If they are, check the distance to the player to see if they are within range
            if (Vector2.Distance(transform.position, hit.transform.position) < 1.5f)
            {
                //If int range, then call their interact method
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                interactable.Interact();
            }
        }
    }

    private void Update()
    {
        //This is fine, but perhaps having all characters have the prompt when then have new dialogues? Not sure how to do that. Maybe a reference from the dialogue trigger that checks global variables and calls the ShowPrompt in the IInteractable when specific variables change
        //The above idea could be implemented now, with the Global Variables Listener, but perhaps it will add too many moving parts
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        
        //This constantly raycasts from mouse position, checking if there is any interactable object hit
        Ray ray = _mainCamera.ScreenPointToRay(_pointerPositionInputAction.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out var hit))
        {
            //If there is, it checks if it is a new one and calls the show prompt method, so the player knows that they can interact with this object
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            //This check is to avoid the method from being called all the time. With this, it is called only once, when a new interactable is identified on the raycast. It also hides the prompt from the interactable when the player is no longer hovering the mouse over it
            if (interactable != _previousInteractable)
            {
                interactable?.ShowPrompt();
                _previousInteractable?.HidePrompt();
                _previousInteractable = interactable;
            }
        }
        
    }
}
