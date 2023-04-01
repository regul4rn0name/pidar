using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject dest;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;
    public int spawnCount = 1;
    public float spawnInterval = 1f; // интервал между созданиями объектов
    private int repeatCounter = 0;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (repeatCounter < 900) // продолжаем создание до достижения лимита
        {
            
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            spawnedObject.transform.parent = transform;
            repeatCounter++;

            yield return new WaitForSeconds(spawnInterval); // ждем указанный интервал
        }
    }


}
