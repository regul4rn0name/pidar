using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bl : MonoBehaviour
{
    public float speed = 5f;
    
    void Update()
    {
        // перемещаем объект вперед с постоянной скоростью
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
