using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemymovemnt_mario : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D rb;
    private bool dir = false;

    private bool air2 = false;
    
   
    

    // Update is called once per frame
    void Update()
    {
        if (dir)
        {
            rb.AddForce(Vector2.left* speed, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.right* speed, ForceMode2D.Force);
        }
        GameObject otherObject = GameObject.Find("mario");
        Playermovementmario otherScript = otherObject.GetComponent<Playermovementmario>();
        air2 = otherScript.air;




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
            StartCoroutine(ChangeDirectionWithDelay(0.5f));

        }
        if (collision.gameObject.CompareTag("Player")&& air2)
        {
            Destroy(gameObject);
            Debug.Log("zlupka");

        }
        
    }

}
