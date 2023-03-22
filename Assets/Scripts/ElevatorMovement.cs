using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 _topFloorPosition;

    [SerializeField]
    private Vector3 _baseFloorPosition;

    [SerializeField]
    private Vector3 _base2FloorPosition;

    [SerializeField]
    private float _moveSpeed = 1f;

    private int _currentFloor = 1;

    [SerializeField]
    private enum _floorNumber
    {
        1,2,3;
}

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float step = _moveSpeed * Time.deltaTime;

        if (1 == 1) //variable code comes here
        {
            if (_currentFloor != 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, _topFloorPosition, step);
            }
        }

        if (2 == 2) //variable code comes here
        {
            if (_currentFloor != 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, _baseFloorPosition, step);
            }
        }

        if (3 == 3) //variable code comes here
        {
            if (_currentFloor != 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, _base2FloorPosition, step);
            }
        }
    }
}