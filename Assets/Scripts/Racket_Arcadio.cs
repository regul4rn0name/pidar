using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket_Arcadio : MonoBehaviour
{
    // Start is called before the first frame update



    public float speed = 150;


    void FixedUpdate()
    {
        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {


        }
    }
