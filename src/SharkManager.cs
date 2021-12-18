using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkManager : MonoBehaviour
{
    public GameObject sharkInstance;
    public GameObject[] spawnPoints;

    public float spawnMaxTime = 0.0f;
    private float spawnTargetTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTargetTime = spawnMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTargetTime -= Time.deltaTime;
        if (spawnTargetTime <= 0.0f) {
            int index = Random.Range(0, spawnPoints.Length - 1);
            Instantiate(sharkInstance, spawnPoints[index].transform.position, Quaternion.identity);

            spawnTargetTime = spawnMaxTime;
        }
    }
}
