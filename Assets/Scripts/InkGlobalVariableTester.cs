using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkGlobalVariableTester : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        
    }
}
