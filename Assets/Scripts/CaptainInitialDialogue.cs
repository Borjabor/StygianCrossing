using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainInitialDialogue : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _captain;
    
    void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.8f);
        _captain.Interact();
    }
}
