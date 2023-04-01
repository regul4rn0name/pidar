using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroommovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private bool dir = false;


    // Update is called once per frame
    void Update()
    {
        if (dir)
        {
            rb.AddForce(Vector2.left*speed, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.right*speed, ForceMode2D.Force);
        }
    }
    private IEnumerator ChangeDirectionWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(0f);

        dir = !dir;
        Debug.Log(dir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick") || collision.gameObject.CompareTag("mushroom"))
        {
            StartCoroutine(ChangeDirectionWithDelay(0f));
        }
    }
}
