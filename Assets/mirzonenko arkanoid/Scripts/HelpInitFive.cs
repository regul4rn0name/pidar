﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpInitFive : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 40f;
    public float gridX = 11f;
    public float gridY = 6f;
    public float spacing = 20;

    public float gridX2 = -3f;
    public float gridY2 = 5f;

    void Start()
    {
        int N = 11;
        int center = N / 2;
        for (int i = 0; i < gridY; i++)
        {
            for (int j = 0; j < gridX; j++)
            {
                if (i <= center)
                {
                    if (j >= center - i && j <= center + i)
                    {
                        Vector3 pos = new Vector3(j, i, 0) * spacing;
                        Instantiate(prefab, pos, Quaternion.identity);
                    }
                }
                else
                {
                    if (j >= center + i - N + 1 && j <= center - i + N - 1)
                    {
                        Vector3 pos = new Vector3(j, i, 0) * spacing;
                        Instantiate(prefab, pos, Quaternion.identity);
                    }
                }
            }
        }

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }

        for (int y = 0; y < gridY2; y++)
        {
            for (int x = -10; x < gridX2; x++)
            {
                Vector3 pos = new Vector3(x, y, 0) * spacing;
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }
    }
}
