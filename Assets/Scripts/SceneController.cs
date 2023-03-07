using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 10f);

        if (hit.collider != null)
        {
            print(hit.collider.name);
            
            if (hit.collider.gameObject.CompareTag(MyTags.Scene))
            {
                hit.collider.gameObject.GetComponent<SceneComponent>()._isActive = true;
            }
        }
     

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, -Vector2.up);
    }
}
