using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    // Объект, который нужно создать
    public GameObject objectToSpawn;
    public GameObject dest;
    public Rigidbody2D rb;

    // Позиция и поворот создаваемого объекта
    public Vector2 spawnPosition;
    public Quaternion spawnRotation;


    // Количество объектов, которые нужно создать
    public int spawnCount = 1;
    private int repeatCounter = 0;
    private void Start()
    {
        InvokeRepeating("SpawnObject", 0f, 1f);
    }

    // Метод для создания объектов
    public void SpawnObject()
    {
        if (Input.GetKey("e")) {
        repeatCounter++;

        // проверяем значение счетчика
        if (repeatCounter > 20)
        {
            CancelInvoke("SpawnObject"); // прекращаем повторения
            return;
        }

        // Получаем позицию игрока
        Vector2 playerPosition = transform.position;

        // Вычисляем позицию перед игроком
        Vector2 spawnPosition = new Vector2(playerPosition.x+1, playerPosition.y) + new Vector2(transform.forward.x, transform.forward.y) * 2f;


        // Создаем один объект на позиции перед игроком
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

        // Делаем созданный объект дочерним по отношению к этому объекту
        spawnedObject.transform.parent = transform;
        }
    }
}
