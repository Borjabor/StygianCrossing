using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using Articy.UnityImporterTutorial.GlobalVariables;
using UnityEditor;
using UnityEngine;

public class GlobalVariableListener : MonoBehaviour
{
    protected virtual void Start()
    {
        // we get the default variable storage from our database and add a listener to the notification manager
        // to call our supplied method every time any Variable inside the namespace "GameState" is changed.
        ArticyDatabase.DefaultGlobalVariables.Notifications.AddListener("GameState.*", MyGameStateVariablesChanged);
    }
    
    // here we handle every variable change inside the "GameState" namespace
    protected virtual void MyGameStateVariablesChanged(string aVariableName, object aValue)
    {
        /*if (aVariableName == "VariableSet.VariableName" && (type)aValue == desiredValue)
        {
            run desired code;
        }*/

        
    }
}
