using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private Transform _playerTransform;
    
    void Update()
    {
        var position = _playerTransform.position;
        transform.position = new Vector3(position.x + 1f, position.y + 1.59f, transform.position.z);
    }
}
