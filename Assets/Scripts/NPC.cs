using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : GlobalVariableListener
{

    [SerializeField]
    private Vector3 _newPosition;

    [SerializeField]
    private bool _changePosition;

    // Update is called once per frame
    void Update()
    {
        if (_changePosition)
        {
            transform.position = _newPosition;
        }

        _changePosition = false;
    }

    protected override void OnGlobalVariablesChanged(string aVariableName, object aValue)
    {
        if (aVariableName == "GameState.dialogue1Visited" && (bool)aValue == true)
        {
            _changePosition = true;
        }
        
    }
}
