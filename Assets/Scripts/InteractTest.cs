using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class InteractTest : MonoBehaviour, IInteractable
{
    private Outline _outline;

    [SerializeField] private TextAsset _dialogue;
    

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0f;
    }

    public void Interact()
    {
        Debug.Log($"Talk");
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
