using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContol : MonoBehaviour
{
    public float speed = 5f;
    public GameObject objectToSpawn;
    public float min_Y, max_Y;

    // Start is called before the first frame update
    
    public int spawnCount = 1;
    private int repeatCounter = 10;
  private void Start()
{
    InvokeRepeating("SpawnObject", 0f, 0.5f); // вызываем метод SpawnObject() с перерывом в пол секунды
}
  public void SpawnObject()
{
    Vector3 spawnPosition = transform.position;
    Quaternion spawnRotation = Quaternion.identity;

    Instantiate(objectToSpawn, spawnPosition, spawnRotation);

    repeatCounter++;

    // необходимо ограничить количество создаваемых объектов, чтобы не перегружать сцену
    if (repeatCounter <= spawnCount)
    {
        CancelInvoke("SpawnObject");
    }
}
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
   
    void MovePlayer()
    {
        if(Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_Y)
                temp.y = max_Y;

            transform.position = temp;

        }

       if(Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_Y)
                temp.y = min_Y;

            transform.position = temp;


        }
    }
}
