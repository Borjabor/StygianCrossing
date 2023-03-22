using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : DialogueTrigger
{
    [SerializeField] private GlobalVariableListener _listener;
    
    private void OnEnable()
    {
        _listener.GlobalVariableChanged += Print;
    }
    
    private void OnDisable()
    {
        _listener.GlobalVariableChanged -= Print;
    }
    
    private void Print(string arg1, object arg2)
    {
        if (arg1 == GlobalVariableListener.GotTip && (bool)arg2)
        {
            Debug.Log($"Got Tip");
        }
    }

    public override void Interact()
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        DialogueManager.GetInstance().SetPlayer();
        DialogueManager.GetInstance().EnterDialogue(_dialogue);
    }


   
    
    
}
