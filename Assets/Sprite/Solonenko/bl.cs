using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bl : MonoBehaviour
 {   
    public float speed = 5f;
   private int enemulin = 4;
    void Update()
    {  
        // перемещаем объект вперед с постоянной скоростью
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
   private void OnTriggerEnter2D(Collider2D collision)
{
    // проверяем, касается ли объект объекта с тегом "dedwall"
    if (collision.gameObject.CompareTag("dedwall"))
    {
        enemulin--;
        // уничтожаем объект
        Destroy(gameObject);
    }
    
}
}
