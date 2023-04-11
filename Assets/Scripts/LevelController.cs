using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField]
    private GlobalVariableListener _listener;

    private bool _margaretApprove;

    private void OnEnable()
    {
        _listener.GlobalVariableChanged += SelectScene;
        _listener.GlobalVariableChanged += ChangeScene;
    }

    private void OnDisable()
    {
        _listener.GlobalVariableChanged -= SelectScene;
        _listener.GlobalVariableChanged -= ChangeScene;
    }

    private void SelectScene(string arg1, object arg2)
    {
        if (arg1 == $"GlobalVariables.ApproveMargaret" && (bool)arg2)
        {
            _margaretApprove = true;
        }

        else
        {
            _margaretApprove = false;
        }
    }

    private void ChangeScene(string arg1, object arg2)
    {
        if (arg1 == $"GlobalVariables.CaptainFinal" && (bool)arg2)
        {
            if (_margaretApprove)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }

            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            }  
        }
    }
}
