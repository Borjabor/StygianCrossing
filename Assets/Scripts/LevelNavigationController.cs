using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNavigationController : MonoBehaviour
{
    [SerializeField]
    private Transform _targetPosition;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(MyTags.Player))
        {
            other.gameObject.transform.position = _targetPosition.position;
            print("teleporting" + other.gameObject.name);
        }
    }
}
