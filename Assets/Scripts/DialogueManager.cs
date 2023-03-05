using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameObject[] _choices;
    private TextMeshProUGUI[] _choicesText;
    
    

    private Story _currentStory;
    private bool _isDialoguePlaying;
    
    

    private void Awake()
    {
        if(instance != null) Debug.Log($"There is another Dialogue Manager");
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        _isDialoguePlaying = false;
        _dialoguePanel.SetActive(false);
        _choicesText = new TextMeshProUGUI[_choices.Length];
        int index = 0;
        foreach (var choice in _choices)
        {
            _choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if(_gameState.Value is States.DIALOGUE or States.PAUSED) return;
        //if(!_isDialoguePlaying) return;
        
        //In the tutorial, he gets an instance of the input manager to continue the story if the player presses the submit button, that must be because he teaches the dialogue too in a platformer, so gamepad must be setup. In our case, that might not be necessary since we're using just the mouse, so we can call it through a unity event from the Canvas
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        _gameState.Value = States.DIALOGUE;
        _currentStory = new Story(inkJSON.text);
        //_isDialoguePlaying = true;
        _dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        _gameState.Value = States.NORMAL;
        //_isDialoguePlaying = false;
        _dialoguePanel.SetActive(false);
        _dialogueText.text = "";
    }

    public void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            _dialogueText.text = _currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    //While it works the way it is setup, and will remain as such for now, this method seems vary rigid and not at all dynamic. Would be better to find a way to allow for more choices and to make them automatically update in the UI
    private void DisplayChoices()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;

        //Makes sure UI can support number of choices coming in
        if (currentChoices.Count > _choices.Length)
        {
            Debug.LogError($"More choices than UI can support. Number of choices given: {currentChoices.Count}");
        }

        int index = 0;
        foreach (var choice in currentChoices)
        {
            _choices[index].gameObject.SetActive(true);
            _choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < _choices.Length; i++)
        {
            _choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        _currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
