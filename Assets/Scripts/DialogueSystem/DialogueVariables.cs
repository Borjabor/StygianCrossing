using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;
using Object = Ink.Runtime.Object;

public class DialogueVariables
{
    public Dictionary<string, Object> _variables { get; private set; }

    public DialogueVariables(TextAsset loadGlobalsJSON)
    {
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);

        _variables = new Dictionary<string, Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            _variables.Add(name, value);
            Debug.Log($"Initialized global dialogue variable: {name} = {value}");
        }
    }
    
    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }
    
    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    
    private void VariableChanged(string name, Object value)
    {
        if (_variables.ContainsKey(name))
        {
            _variables.Remove(name);
            _variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Object> variable in _variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
