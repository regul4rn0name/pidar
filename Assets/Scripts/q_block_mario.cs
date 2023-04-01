using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class q_block_mario : MonoBehaviour

{
    public Rigidbody2D rb;
    public Sprite newSprite;
    public Animator animator;
    public GameObject objectToSpawn;
    public GameObject dest;

    // Позиция и поворот создаваемого объекта
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;


    // Количество объектов, которые нужно создать
    public int spawnCount = 1;
    private int repeatCounter = 0;







    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("blockbeat", true);
            SpawnObject();

        }
    }
    public void SpawnObject()
    {
        repeatCounter++;

        // проверяем значение счетчика
        if (repeatCounter > 1)
        {
            CancelInvoke("FunctionName"); // прекращаем повторения
            return;
        }
        Vector2 randomPosition = new Vector2(-7, -1);

        // Создаем один объект на случайной позиции
        GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, spawnRotation);

        // Делаем созданный объект дочерним по отношению к этому объекту
        spawnedObject.transform.parent = transform;
    }

}


