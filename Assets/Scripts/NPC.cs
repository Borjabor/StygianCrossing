using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    [SerializeField]
    private Vector3 _newPosition;

    [SerializeField]
    private bool _changePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_changePosition)
        {
            transform.position = _newPosition;
        }

        _changePosition = false;
    }
}
