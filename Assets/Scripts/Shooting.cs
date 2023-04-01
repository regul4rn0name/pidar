using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Transform characterTransform = gameObject.GetComponent<Transform>();
        Vector2 characterPosition = characterTransform.position;
        Vector2 characterLookDirection = characterTransform.right;

        // Instantiate the bullet
        GameObject bulletObject = Instantiate(gameObject, characterPosition, Quaternion.identity);
        bullet bulletScript = bulletObject.GetComponent<bullet>();

        // Add force to the bullet
        bulletScript.rb.AddForce(characterLookDirection * speed, ForceMode2D.Impulse);
    }
}
    

