using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateincrement = 1f;
    public float xLimit;
    public float maxTimeLife = 2f;

    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {

        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateincrement;

            float rand = Random.Range(-xLimit,xLimit);

            Vector2 spawnPosition = new Vector2(x:rand, y:8f);

            GameObject meteor = Instantiate (asteroidPrefab, spawnPosition, Quaternion.identity);

            Destroy(meteor, maxTimeLife);
        }
        
    }
}
