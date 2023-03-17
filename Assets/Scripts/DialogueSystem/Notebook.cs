using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : DialogueTrigger
{

    public override void Interact()
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        DialogueManager.GetInstance().SetPlayer();
        DialogueManager.GetInstance().EnterDialogue(_dialogue);
    }
}
