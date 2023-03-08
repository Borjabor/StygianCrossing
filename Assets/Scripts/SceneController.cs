using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 10f);
        //
        // if (hit.collider != null)
        // {
        //     print(hit.collider.name);
        //     
        //     if (hit.collider.gameObject.CompareTag(MyTags.Scene))
        //     {
        //         hit.collider.gameObject.GetComponent<SceneComponent>()._isActive = true;
        //     }
        // }
     

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(MyTags.Scene))
        {
            col.gameObject.GetComponent<SceneComponent>()._isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(MyTags.Scene))
        {
            other.gameObject.GetComponent<SceneComponent>()._isActive = false;
        }
    }
}
