using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private float spawnCountdown;
    public float spawnInterval;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;

        if(spawnCountdown <= 0)
        {
            SpawnObject();
            spawnCountdown = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
