using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementGallaga: MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    private bool jumping = false;
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
            jumping = true;

        }
        else
        {
            jumping = false;
        }
        if (Input.GetKey("s"))
        {
            down = true;

        }
        else
        {
            down = false;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 6;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 6;

        Vector2 direction = Quaternion.AngleAxis(45, Vector2.up) * new Vector2(x, 0);

        transform.Translate(direction);


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
        if (jumping )
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Force);
            
        }
        if (down)
        {
            rb.AddForce(Vector2.down * speed, ForceMode2D.Force);
        }
    }
   
}