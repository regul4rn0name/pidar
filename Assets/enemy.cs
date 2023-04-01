using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    private int enemulin = 4;
    public float speeden;
    public float min_X;
    public GameObject objectToSpawn;
    private float killCount = 0;

    private void Start()
    { 
        // Вызываем метод SpawnObject() с перерывом в пол секунды
        InvokeRepeating("SpawnObject", 0f, 1f);
    }

    private void FixedUpdate()
    {
        // Перемещаем объект вниз с постоянной скоростью
        transform.Translate(Vector2.down * Time.deltaTime * speeden);

        // Получаем текущую позицию объекта
        Vector2 currentPos = transform.position;

        // Если объект достиг минимальной высоты
        if (currentPos.x < min_X)
        {
            // Останавливаем его движение
            speeden = 0f;
        }
    }

    public int spawnCount = 100;
    private int repeatCounter = 0;

    public void SpawnObject()
    {
        repeatCounter++;

        // Создаем новый объект
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(objectToSpawn, spawnPosition, spawnRotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bl"))
        {       
                       
            EnemyCounter.Instance.EnemyDied();
            Destroy(gameObject);      
            }
        }
   
}
