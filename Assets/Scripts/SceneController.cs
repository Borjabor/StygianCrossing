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
        
        else if (col.CompareTag(MyTags.SmokingRoom))
        {
            col.gameObject.GetComponent<SmokingRoom>()._isActive = true;
            col.gameObject.GetComponent<SmokingRoom>()._playSound = true;
        }
        
        else if (col.CompareTag(MyTags.StorageRoom))
        {
            col.gameObject.GetComponent<StorageRoom>()._isActive = true;
            col.gameObject.GetComponent<StorageRoom>()._playSound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(MyTags.Scene))
        {
            other.gameObject.GetComponent<SceneComponent>()._isActive = false;
            other.gameObject.GetComponent<SceneComponent>()._playSound = false;
        }
        
        else if (other.CompareTag(MyTags.SmokingRoom))
        {
            other.gameObject.GetComponent<SmokingRoom>()._isActive = false;
            other.gameObject.GetComponent<SmokingRoom>()._playSound = false;
        }
        
        else if (other.CompareTag(MyTags.StorageRoom))
        {
            other.gameObject.GetComponent<StorageRoom>()._isActive = false;
            other.gameObject.GetComponent<StorageRoom>()._playSound = false;
        }
    }
}
