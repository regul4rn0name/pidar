using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket_Arcadio : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;

    public float speed = 150;
    private bool left = false;
    private bool right = false;

    void FixedUpdate()
    {


        if (left)
        {
            rb.AddForce(Vector2.left * speed, ForceMode2D.Force);

        }
        if (right)
        {
            rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
        }


    }


    // Use this for initialization
    void Start()
    {

    }

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

    }
}
