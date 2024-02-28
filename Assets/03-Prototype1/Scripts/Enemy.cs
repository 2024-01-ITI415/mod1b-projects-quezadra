using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float speed = 1f;
    public float leftAndRightEdge = 5f; // Change to upAndDown and adjust the maze restrictions
    public Transform[] patrolPoints;
    private int currentPoint = 0;

    void Start()
    {
        transform.position = patrolPoints[0].position;
    }

    void Update()
    {
        if (transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
            if (currentPoint >= patrolPoints.Length)
            {
                currentPoint = 0; // Reset to the first point if it exceeds the array length
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, speed * Time.deltaTime);
    }
   
}


   

