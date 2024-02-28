using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    // Speed at which the AppleTree moves
    public float speed = 1f;
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    // Chance that the AppleTree will change direction
    public float chanceToChangeDirection;
    // Rate at which Apples will be instantiate
    public float secondsBetweenAppleDrops = 2f;

    void Start()
    {
        // Dropping apples every two seconds
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
    }

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction Randomly
        if (pos.x < -leftAndRightEdge)
        {
            // move right
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            // move left
            speed = -Mathf.Abs(speed);
        }

        // Randomly change direction
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1; // Change direction
        }
    }
    void FixedUpdate()
    {
        // Changing Direction Randomly is now t
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1; // Change direction
        }
    }
}