using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class DialogueTrigger : MonoBehaviour, IInteractable
{
    private Outline _outline;

    [SerializeField] private TextAsset _dialogue;
    [SerializeField] private GameState _gameState;
    [Tooltip("The sprite you want to use as the portrait for the character")]
    [SerializeField] private Sprite _portraitImage;
    [Tooltip("Drag the Portrait object from within Dialogue Panel > Image > Portrait")]
    [SerializeField] private Image _portrait;
    

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0f;
    }

    public void Interact()
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        DialogueManager.GetInstance().EnterDialogueMode(_dialogue);
        _portrait.sprite = _portraitImage;
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
