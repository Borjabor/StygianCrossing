using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContainer : MonoBehaviour
{

    [SerializeField]
    private GameObject _variableObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.transform.CompareTag(MyTags.InspectableObject))
            {
                Instantiate(_variableObject);
            } 
        }
    }


}
