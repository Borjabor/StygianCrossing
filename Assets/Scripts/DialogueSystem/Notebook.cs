using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{

    [SerializeField]
    private RectTransform _notebook;

    [SerializeField]
    private RectTransform _targetPosition;
    
    [SerializeField]
    private RectTransform _originalPosition;
    
    private bool _notebookReveal = false;

    private int _notificationCount = 0;

    [SerializeField]
    private TextMeshProUGUI _notificationCountText;

    [SerializeField]
    private GlobalVariableListener _listener;

    [SerializeField]
    private GameObject[] _objectives;

    [SerializeField]
    private GameObject[] _objectivesDone;
    
    
    private void OnEnable()
    {
        _listener.GlobalVariableChanged += ObjectiveReveal;
    }
    
    private void OnDisable()
    {
        _listener.GlobalVariableChanged -= ObjectiveReveal;
    }

    private void Update()
    {
        _notificationCountText.text = _notificationCount.ToString();
    }

    protected virtual void ObjectiveReveal(string arg1, object arg2)
    {
        if (arg1 == $"GlobalVariables.CaptainQuest" && (bool)arg2)
        {
            print("Captain Convo Completed");
            _objectives[0].SetActive(true);
            _notificationCount++;
        }

        if (arg1 == $"GlobalVariables.WaltConvo1" && (bool)arg2)
        {
            _objectives[1].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.WaltConvo2" && (bool)arg2)
        {
            _objectives[2].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.MargaretConvo1" && (bool)arg2)
        {
            _objectives[3].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.JackConvo1" && (bool)arg2)
        {
            _objectives[4].SetActive(true);
            _notificationCount++;
        }
        //end of first page
        
        if (arg1 == $"GlobalVariables.JeanKeyConvo" && (bool)arg2)
        {
            _objectives[5].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.JackConvo2" && (bool)arg2)
        {
            _objectives[6].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.JackConvo2" && (bool)arg2)
        {
            _objectives[7].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.MargaretConvo2" && (bool)arg2)
        {
            _objectives[8].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.JackConvo3" && (bool)arg2)
        {
            _objectives[9].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.ArthurConvo3" && (bool)arg2)
            //arthur and margaret final convo
        {
            _objectives[10].SetActive(true);
            _notificationCount++;
        }
        
        //FOR COMPLETED OBJECTIVES
        // >>>>>>>>>>>>>>>>>>
        
        if (arg1 == $"GlobalVariables.CaptainQuest" && (bool)arg2)
        {
            _objectivesDone[0].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.MargaretConvo1" && (bool)arg2)
        {
            _objectivesDone[1].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.WaltConvo2" && (bool)arg2)
        {
            _objectivesDone[2].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.WaltConvo3" && (bool)arg2)
        {
            _objectivesDone[3].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.JackConvo1" && (bool)arg2)
        {
            _objectivesDone[4].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.JeanKeyConvo" && (bool)arg2)
        {
            _objectivesDone[5].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.StorageKey" && (bool)arg2)
        {
            _objectivesDone[6].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.ArthurEvidence1" && (bool)arg2)
        {
            _objectivesDone[7].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.JackConvo3" && (bool)arg2)
        {
            _objectivesDone[8].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.newsPaper" && (bool)arg2)
        {
            _objectivesDone[9].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.ArthurEvidence2" && (bool)arg2)
        {
            _objectivesDone[10].SetActive(true);
        }
        
        if (arg1 == $"GlobalVariables.CaptainFinal" && (bool)arg2)
        {
            _objectivesDone[11].SetActive(true);
        }

    }

    public void NotebookReveal()
    {
        
        float _moveSpeed = 1f;
        float step = _moveSpeed * Time.deltaTime;
        
        if (!_notebookReveal)
        {
            _notebook.position = _targetPosition.position;
            _notebookReveal = true;
            _notificationCount = 0;
        }

        else
        {
            _notebook.position = _originalPosition.position;
            _notebookReveal = false;
        }
        
    }
    
    
    
    
}
