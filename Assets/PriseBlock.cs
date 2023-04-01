using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriseBlock : MonoBehaviour
{

    public GameObject newObjectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(newObjectPrefab, transform.position, Quaternion.identity);
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
