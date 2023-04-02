using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : DialogueTrigger
{

    [SerializeField]
    private RectTransform _notebook;

    [SerializeField]
    private RectTransform _targetPosition;
    
    [SerializeField]
    private RectTransform _originalPosition;
    
    private bool _notebookReveal = false;


    private void Start()
    {
        // _originalPosition = transform.position;
    }

    // [SerializeField] private GlobalVariableListener _listener;
    //
    // private void OnEnable()
    // {
    //     _listener.GlobalVariableChanged += Print;
    // }
    //
    // private void OnDisable()
    // {
    //     _listener.GlobalVariableChanged -= Print;
    // }
    //
    // private void Print(string arg1, object arg2)
    // {
    //     if (arg1 == "GameState.gotTip" && (bool)arg2)
    //     {
    //         Debug.Log($"Got Tip");
    //     }
    // }

    public override void Interact()
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        DialogueManager.GetInstance().SetPlayer();
        DialogueManager.GetInstance().EnterDialogue(_dialogue);
    }

    public void NotebookReveal()
    {
        
        float _moveSpeed = 1f;
        float step = _moveSpeed * Time.deltaTime;
        
        if (!_notebookReveal)
        {
            _notebook.position = _targetPosition.position;
            _notebookReveal = true;   
        }

        else
        {
            _notebook.position = _originalPosition.position;
            _notebookReveal = false;
        }
        
    }

    public void NotebookHide()
    {
        
    }
    
    
}
