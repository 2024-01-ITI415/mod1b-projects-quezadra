using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector")]
    
    public float speed = 1f;
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    // Chance that the AppleTree will change direction
    public float chanceToChangeDirection;
    public float y_movement;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction Randomly
        if (pos.z < -leftAndRightEdge)
        {
            // move right
            speed = Mathf.Abs(speed);
        }
        else if (pos.z > leftAndRightEdge)
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

   /// void OnTriggerEnter(Collider other)
    /// <summary>
   /// void OnTriggerEnter(Collider other)
   /// </summary> other.gameObject;
    ///    if (other.gameObject.CompareTag("_Player"))
     ///   {
        ///    Destroy();
       /// }
    
    void FixedUpdate()
    {
        
    }


}
