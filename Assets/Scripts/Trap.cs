using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Trap : MonoBehaviour
{
    private int side;
    private float speed;
    [SerializeField] private float step;
    [SerializeField] private Vector3 moveVector;

    private void Start()
    {
       side = Random.Range(0, 2);
        SetSide();
    }

    void Update()
    {
        if (transform.position != moveVector)
        {
            transform.position = Vector3.Lerp(transform.position, moveVector, speed);
            speed += step;
        }
        else
        {
            SetSide();
        }
    }

    private void SetSide()
    {
        switch (side)
        {
            case 0:
                moveVector = new Vector3(transform.position.x, transform.position.y - 1, 0);
                side = 1;
                speed = 0;
                break;
            case 1:
                moveVector = new Vector3(transform.position.x, transform.position.y + 1, 0);
                side = 0;
                speed = 0;
                break;
        }
    }
}
