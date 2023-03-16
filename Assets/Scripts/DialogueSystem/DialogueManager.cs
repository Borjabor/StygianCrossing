using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Range(1,10)][SerializeField] private int _textSpeed;
    private float _typingSpeed;
    private Coroutine _displayLineCoroutine;
    private bool _canContinueToNextLine = true;

    [SerializeField] private TextAsset _loadGlobalsJSON;
    
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _speakerName;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    private string _fullText;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameObject _continueIcon;
    [SerializeField] private GameObject[] _choices;
    private TextMeshProUGUI[] _choicesText;
    
    private const string SPEAKER_TAG = "speaker";

    private DialogueVariables _dialogueVariables;
    
    private Story _currentStory;
    private bool _isDialoguePlaying;
    private bool _finishText;
    private bool _isPlayer;


    private void Awake()
    {
        if(instance != null) Debug.Log($"There is another Dialogue Manager");
        instance = this;

        _dialogueVariables = new DialogueVariables(_loadGlobalsJSON);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        _isPlayer = false;
        _typingSpeed = 0.05f / _textSpeed;
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
        
        _dialogueVariables.StartListening(_currentStory);
        
        _dialoguePanel.SetActive(true);
        _speakerName.text = _isPlayer? "Jeff's Inner Thoughts" : "???"; //Default value to detect where it is missing;

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        _gameState.Value = States.NORMAL;
        
        _dialogueVariables.StopListening(_currentStory);
        
        _dialoguePanel.SetActive(false);
        _fullText = "";
        _dialogueText.text = "";
    }

    public void ContinueStory()
    {
        if(!_canContinueToNextLine) return;
        _finishText = false;
        if (_currentStory.canContinue)
        {
            if (_isPlayer)
            {
                StartCoroutine(PlayerNotebook());
            }
            else
            {
                if(_displayLineCoroutine != null) StopCoroutine(_displayLineCoroutine);
                _displayLineCoroutine = StartCoroutine(DisplayLine(_currentStory.Continue()));
            }
            HandleTags(_currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            
            if(splitTag.Length != 2) Debug.Log($"Tag could not be parsed: {tag}");
            
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey) //In the end I just used the speaker tag, so the switch is not necessary. Left it as is in case I want to add stuff later. He used an animator to setup the portraits, but I feel the way I did it makes it more designer friendly, that is, them being called from the DialogueTrigger script
            {
                case SPEAKER_TAG:
                    _speakerName.text = tagValue;
                    break;
                default:
                    Debug.Log($"Tag came but is not currently being handled: {tag}");
                    break;
                
            }
        }
        
    }

    private IEnumerator PlayerNotebook()
    {
        _dialogueText.text = _currentStory.Continue();
        while (_currentStory.canContinue) _dialogueText.text += _currentStory.Continue();
        yield return new WaitForSeconds(0.1f);
        _scrollbar.value = 0;
        DisplayChoices();
    }
    private IEnumerator DisplayLine(string line)
    {
        _continueIcon.SetActive(false);
        HideChoices();
        _canContinueToNextLine = false;
        
        //_dialogueText.text = "<color=#808080ff>" + _fullText + "</color>";
        _dialogueText.text = "";

        bool isAddingRichTextTag = false;

        foreach (char letter in line.ToCharArray())
        {
            if (_finishText)
            {
                _dialogueText.text = /*"<color=#808080ff>" + _fullText + "</color>" +*/ line;
                yield return new WaitForSeconds(0.1f);
                _scrollbar.value = 0;
                _finishText = false;
                break;
            }

            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                _dialogueText.text += letter;
                _scrollbar.value = 0;
                if (letter == '>') isAddingRichTextTag = false;
            }
            else
            {
                _dialogueText.text += letter;
                _scrollbar.value = 0;
                yield return new WaitForSeconds(_typingSpeed);
            }
            
        }

        //_fullText += _dialogueText.text;
        _continueIcon.SetActive(true);
        DisplayChoices();
        _canContinueToNextLine = true;
    }

    public void FinishText()
    {
        _finishText = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in _choices)
        {
            choiceButton.SetActive(false);
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

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        _dialogueVariables._variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning($"Ink variable was not found: {variableName}");
        }

        return variableValue;
    }

    public void SetPlayer()
    {
        _isPlayer = true;
    }
    
    public void ClearPlayer()
    {
        _isPlayer = false;
    }
}
