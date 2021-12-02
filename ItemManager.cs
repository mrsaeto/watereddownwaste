﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject trashInstance;

    public float spawnMaxTime = 0.0f;
    private float spawnTargetTime = 0.0f;

    public GameObject[] spawnPoints;

    void Start()
    {
        spawnTargetTime = spawnMaxTime;
    }

    void Update()
    {
        spawnTargetTime -= Time.deltaTime;
        if (spawnTargetTime <= 0.0f) {
            int index = Random.Range(0, spawnPoints.Length - 1);
            Instantiate(trashInstance, spawnPoints[index].transform.position, Quaternion.identity);
            spawnTargetTime = spawnMaxTime;
        }
    }
}
