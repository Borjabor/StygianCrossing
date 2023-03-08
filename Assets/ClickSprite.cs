using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClickSprite : MonoBehaviour
{

    [SerializeField]
    private float _destroyTime = 0.1f;
    
    private void Start()
    {
        Destroy(gameObject,_destroyTime);
    }
}
