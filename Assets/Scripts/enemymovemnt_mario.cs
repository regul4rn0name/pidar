using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovemnt_mario : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D rb;
    private bool dir = false;
    

    // Update is called once per frame
    void Update()
    {
        if (dir)
        {
            rb.AddForce(Vector2.left, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.right, ForceMode2D.Force);
        }
    }
    private IEnumerator ChangeDirectionWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        dir = !dir;
        Debug.Log(dir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            StartCoroutine(ChangeDirectionWithDelay(1f));
        }
    }

}
