using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroommario : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
