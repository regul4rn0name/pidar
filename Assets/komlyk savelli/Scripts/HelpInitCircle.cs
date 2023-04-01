﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpInitCircle : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 40f;

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}
