using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement_donkey : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    private bool jumping = false;
    private bool left = false;
    private bool right = false;
    private bool air = false;
    private bool ladder = false;
    private bool climbing = false;
    public float climb;
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
        if (Input.GetKey("w") && !air)
        {
            jumping = true;

        }
        else
        {
            jumping = false;
        }
        if(Input.GetKey("w") && ladder)
        {
            climbing = true;
        }
        else
        {
            climbing = false;
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
        if (jumping )
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            air = true;
        }
        if (climbing)
        {
            rb.AddForce(Vector2.up * climb, ForceMode2D.Force);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            air = false;
        }
        if (collision.gameObject.CompareTag("Barrel"))
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

}