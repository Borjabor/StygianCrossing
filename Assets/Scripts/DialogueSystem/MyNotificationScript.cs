using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using UnityEditor;
using UnityEngine;

public class MyNotificationScript : MonoBehaviour
{
    void Start()
    {
        // we get the default variable storage from our database and add a listener to the notification manager
        // to call our supplied method every time any Variable inside the namespace "GameState" is changed.
        ArticyDatabase.DefaultGlobalVariables.Notifications.AddListener("GameState.*", MyGameStateVariablesChanged);
    }
    // here we handle every variable change inside the "GameState" namespace
    void MyGameStateVariablesChanged(string aVariableName, object aValue)
    {
        // for example:
        // When our exit variable was set to true, we quit the game.
        if(aVariableName == "GameState.exit" && ((bool)aValue) == true)
            Application.Quit();

        // in this example we play a beep when the variable changes
        // its worth noting that we won't hear a beep now every frame once the variable has been set to true. Because our listener method will only
        // be called once, when our variable changes.
        if(aVariableName == "GameState.beep" && ((bool) aValue) == true)
            EditorApplication.Beep();
    }
}
