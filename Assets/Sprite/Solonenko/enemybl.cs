using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybl : MonoBehaviour
{
  public float speed = 5f;

    
    void Update()
    {
      
        // перемещаем объект вперед с постоянной скоростью
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        
    }
   private void OnTriggerEnter2D(Collider2D collision)
{
    // проверяем, касается ли объект объекта с тегом "dedwall"
    if (collision.gameObject.CompareTag("dedwall"))
    {
        
        // уничтожаем объект
        Destroy(gameObject);
    }
}
}
