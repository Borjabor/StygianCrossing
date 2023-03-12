using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Outline))]
public class DialogueTrigger : MonoBehaviour, IInteractable
{
    private Outline _outline;

    [SerializeField] protected TextAsset _dialogue;
    [SerializeField] protected GameState _gameState;
    [Tooltip("The sprite you want to use as the portrait for the character")]
    [SerializeField] protected Sprite _portraitImage;
    [Tooltip("Drag the Portrait object from within Dialogue Panel > Image > Portrait")]
    [SerializeField] protected Image _portrait;

    [SerializeField] private GameObject _prompt;
    
    

    protected void Awake()
    {
        //_outline = GetComponent<Outline>();
        //_outline.OutlineWidth = 0f;
    }

    public virtual void Interact()
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        DialogueManager.GetInstance().ClearPlayer();
        DialogueManager.GetInstance().EnterDialogueMode(_dialogue);
        _portrait.sprite = _portraitImage;
    }

    public void ShowPrompt()
    {
        //_outline.OutlineColor = Color.yellow;
        //_outline.OutlineWidth = 10f;
        _prompt.SetActive(true);
    }

    public void HidePrompt()
    {
        //_outline.OutlineWidth = 0f;
        _prompt.SetActive(false);
    }
}
