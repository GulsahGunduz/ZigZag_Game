using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform ball_Pos;
    Vector3 distance;


    void Start()
    {
        distance = transform.position - ball_Pos.position;
    }

    void Update()
    {
        if (BallMovementController.isFloor == true)
        {
            transform.position = ball_Pos.position + distance;
        }
    }
}
