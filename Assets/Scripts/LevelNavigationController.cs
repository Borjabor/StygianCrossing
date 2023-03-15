using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNavigationController : MonoBehaviour
{
    [SerializeField]
    private Transform _targetPosition;

    [SerializeField]
    private AudioClip _doorAudio;

    private AudioSource _as;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(MyTags.Player))
        {
            _as.PlayOneShot(_doorAudio);
            other.gameObject.transform.position = _targetPosition.position;
            print("teleporting" + other.gameObject.name);
        }
    }
}
