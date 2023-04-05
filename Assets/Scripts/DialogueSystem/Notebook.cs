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
            print("Captain Convo Called");
            _objectives[0].SetActive(true);
            _notificationCount++;
        }
        
        if (arg1 == $"GlobalVariables.ArthurEvidence1" && (bool)arg2)
        {
            _objectives[0].SetActive(true);
            _notificationCount++;
        }
        
        // if (arg1 == $"GlobalVariables.ArthurEvidence1" && (bool)arg2)
        // {
        //     _objectives[0].SetActive(true);
        //     _notificationCount++;
        // }
        //
        // if (arg1 == $"GlobalVariables.ArthurEvidence1" && (bool)arg2)
        // {
        //     _objectives[0].SetActive(true);
        //     _notificationCount++;
        // }
        //
        // if (arg1 == $"GlobalVariables.ArthurEvidence1" && (bool)arg2)
        // {
        //     _objectives[0].SetActive(true);
        //     _notificationCount++;
        // }
        //
        // if (arg1 == $"GlobalVariables.ArthurEvidence1" && (bool)arg2)
        // {
        //     _objectives[0].SetActive(true);
        //     _notificationCount++;
        // }
        //
        // if (arg1 == $"GlobalVariables.ArthurEvidence1" && (bool)arg2)
        // {
        //     _objectives[0].SetActive(true);
        //     _notificationCount++;
        // }
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
