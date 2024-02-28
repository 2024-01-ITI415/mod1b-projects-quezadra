using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    public Transform respawnPoint;
    private float movementX;
    private float movementY;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); //
        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);


    }
    void SetCountText()
    {

       // countText.text = " Count: " + count.ToString();
       // if (count >= 12)
        //{
          //  winTextObject.SetActive(true);
       // }
    }
    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Goal"))
        {
            // put win text here
        }

       
        GameObject collidedWith = other.gameObject;
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            RespawnPlayer();
        }


        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
          //  count = count + 1;

           // SetCountText();
        }

        //other.gameObject.SetActive(false);

    }
    void RespawnPlayer()
    {
        
        transform.position = respawnPoint.position;
       
        gameObject.SetActive(true);
    }
}
