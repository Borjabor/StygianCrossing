using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walter : MonoBehaviour
{

    [SerializeField]
    private Vector3 _newPos;
    
    [SerializeField]
    private GlobalVariableListener _listener;

    [SerializeField]
    private string _variableName = "WaltConvo2";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnEnable()
    {
        _listener.GlobalVariableChanged += WalterInteraction;
    }

    private void OnDisable()
    {
        _listener.GlobalVariableChanged -= WalterInteraction;
    }

    protected virtual void WalterInteraction(string arg1, object arg2)
    {
        if (arg1 == $"GlobalVariables.{_variableName}" && (bool)arg2)
        {
            transform.position = _newPos;
            print("Moving Walter");
        }
    }
}
