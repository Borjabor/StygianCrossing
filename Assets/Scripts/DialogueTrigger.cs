using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class DialogueTrigger : MonoBehaviour, IInteractable
{
    private Outline _outline;

    [SerializeField] private TextAsset _dialogue;
    [SerializeField] private GameState _gameState;
    
    

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0f;
    }

    public void Interact()
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        DialogueManager.GetInstance().EnterDialogueMode(_dialogue);
    }

    public void ShowPrompt()
    {
        _outline.OutlineColor = Color.yellow;
        _outline.OutlineWidth = 10f;
    }

    public void HidePrompt()
    {
        _outline.OutlineWidth = 0f;
    }
}
