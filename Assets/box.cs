using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class box : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("restart"))
        {
            // Вызов локальной функции OnEnter
            OnEnter();
        }
    }

    void OnEnter()
    {
        Debug.Log("OnEnter has been called");
    }
    // Start is called before the first frame update
    void Start()
    {
     



    }

    // Update is called once per frame
    void Update()
    {
  

    }
}
