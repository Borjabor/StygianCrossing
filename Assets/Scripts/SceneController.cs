using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(MyTags.Scene))
        {
            col.gameObject.GetComponent<SceneComponent>()._isActive = true;
            col.gameObject.GetComponent<SceneComponent>()._playSound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(MyTags.Scene))
        {
            other.gameObject.GetComponent<SceneComponent>()._isActive = false;
            other.gameObject.GetComponent<SceneComponent>()._playSound = false;
        }
    }
}
