using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacman_play_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    
    private bool up = false;
    private bool left = false;
    private bool right = false;
    private bool down = false;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            left = true;
        }
        else
        {
            left = false;
        }
        if (Input.GetKey("d"))
        {
            right = true;
        }
        else
        {
            right = false;

        }
        if (Input.GetKey("w"))
        {
            up = true;

        }
        else
        {
            up = false;
        }
        if (Input.GetKey("s"))
        {
            down = true;

        }
        else
        {
            down = false;
        }


    }
    private void FixedUpdate()
    {
        if (left)
        {
            rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
       
        } 
        
        if (right)
        {
            rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
        }
        if (up)
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Force);
        }
       if (down)
        {
            rb.AddForce(Vector2.down * speed, ForceMode2D.Force);
        }
    }
    


}

