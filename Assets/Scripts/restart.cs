using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene("pacman", LoadSceneMode.Single);
            Debug.Log("pidar");
        }
    }
}
