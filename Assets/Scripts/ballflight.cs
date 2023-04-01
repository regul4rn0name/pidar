using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballflight : MonoBehaviour
{
    private bool flight = false;
    public float flightspeed;
    public Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            flight = true;
        }
    }
    private void FixedUpdate()
    {
        if (flight)
        {
            rb.AddForce(Vector2.right * flightspeed, ForceMode2D.Force);
        }
    }

}