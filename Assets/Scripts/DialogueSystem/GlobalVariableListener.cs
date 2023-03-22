using System;
using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using Articy.UnityImporterTutorial.GlobalVariables;
using UnityEditor;
using UnityEngine;

public class GlobalVariableListener : MonoBehaviour
{
    [Header("Articy Global Variables")] // here we hash Articy's global variables to facilitate access and reduce chance for error from naming difference
    public const string GotTip = "GameState.gotTip";

    //Turining this into an event, so any script that need to track these variables can have its own implementation instead of inheriting from this class
    public event Action<string, object> GlobalVariableChanged; 
    private void OnEnable()
    {
        // here we access to Articy's global variables, then add a listener; The first argument is the variable set's name
        ArticyDatabase.DefaultGlobalVariables.Notifications.AddListener("GameState.*", OnGlobalVariablesChanged);
    }
    
    // this method invokes the event, passing the variable name and its value
    private void OnGlobalVariablesChanged(string aVariableName, object aValue)
    {
        GlobalVariableChanged?.Invoke(aVariableName, aValue);
        
        //Basic format for checking a variables value to run the desired code within a script
        // if (aVariableName == "VariableSet.VariableName" && (type)aValue == desiredValue)
        // {
        //     run desired code;
        // }
    
    }
}
