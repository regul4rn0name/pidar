using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermovementmario : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float speed;
    public float jump;
    private bool jumping = false;
    private bool left = false;
    private bool right = false;
    public bool air = false;
    public float friction;
    public float horizontal;
   
    
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        
        if (Input.GetKey("a"))
        {
            left = true;
            animator.SetBool("runmarioL", true);
           
            
          
            

        }
        else
        {
            left = false;
            animator.SetBool("runmarioL", false);
        }
        if (Input.GetKey("d"))
        {
            right = true;
            animator.SetBool("runmarioR", true);
        }
        else
        {
            right = false;
            animator.SetBool("runmarioR", false);
        }
        if (Input.GetKey("w"))
        {
            jumping = true;
            animator.SetBool("jumpmario", true);
        }
        else
        {
            jumping = false;
            animator.SetBool("jumpmario", false);
        }
       


    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if (left)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            
        }
        if (right)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        // Apply friction if the object is moving and not jumping
        if (rb.velocity.magnitude > 0 && !air|| Input.GetKey("a") || Input.GetKey("d"))
        {
            rb.AddForce(-rb.velocity.normalized * friction, ForceMode2D.Force);
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
        if (other.gameObject.CompareTag("enemy") && !air)
        {

            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        
        if (other.gameObject.CompareTag("mushroom"))
        {

            Transform objectTransform = GetComponent<Transform>();

            // Double the object's scale
            objectTransform.localScale *= 1.2f;
            
        }

    }
}