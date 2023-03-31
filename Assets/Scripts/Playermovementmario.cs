using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovementmario : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    private bool jumping = false;
    private bool left = false;
    private bool right = false;
    private bool air = false;
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
            jumping = true;

        }
        else
        {
            jumping = false;
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
        if (jumping && !air)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            air = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {

            air = false;
        }
        if (other.gameObject.CompareTag("Brick"))
        {

            air = false;
        }


    }
}