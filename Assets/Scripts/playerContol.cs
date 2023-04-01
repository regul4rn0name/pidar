using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerContol : MonoBehaviour
{
    public float speed = 5f;
    public GameObject objectToSpawn;
    public float min_Y, max_Y;
    private bool enemy;
public static int enemyCount = 4;

    
    private void OnDestroy()
    {
        enemyCount--;
    }
    // Start is called before the first frame update
    
    public int spawnCount = 1;
    
   
  private void Start()
{ 
    InvokeRepeating("SpawnObject", 0f, 0.5f); // вызываем метод SpawnObject() с перерывом в пол секунды
}
  public void SpawnObject()
{
    Vector3 spawnPosition = transform.position;
    Quaternion spawnRotation = Quaternion.identity;

    Instantiate(objectToSpawn, spawnPosition, spawnRotation);

    
}
    // Update is called once per frame
    void Update()
    {
        if(enemyCount == 0){
            SceneManager.LoadScene("donkeykong", LoadSceneMode.Single); 
            Debug.Log("gh");
        }
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
     private void OnTriggerEnter2D(Collider2D collision)
{
    // проверяем, касается ли объект объекта с тегом "dedwall"
    if (collision.gameObject.CompareTag("enemybl"))
    {
       {
            Debug.Log("ff");
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
}
 
}
