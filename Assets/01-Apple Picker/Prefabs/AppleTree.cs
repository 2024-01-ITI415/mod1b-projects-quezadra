using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    //prefab for instantiating apples
    public GameObject applePrefab;

    //speed at which the apple tree moves
    public float speed = 1f;

    // distnace where AppleTree turns around
    public float leftandRightEdge = 10f;

    //chance the AppleTree will change direction 

    public float changeToChangeDirection;

    //rate at which Apples will instantiate 
    public float SecondsBetweenAppleDrop;



    void Start()
    {
        // dropping every second 
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>( applePrefab );
        apple.transform.position = transform.position;
        Invoke("DropApple", SecondsBetweenAppleDrop);
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // changing direction

        if (pos.x < -leftandRightEdge)
        {
            speed = Mathf.Abs(speed); // Move ri
        }
        else if (pos.x > leftandRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }


    }
    void FixedUpdate()
    {
        if (Random.value < changeToChangeDirection)
        {
            speed *= -1;
        }
    }
}


