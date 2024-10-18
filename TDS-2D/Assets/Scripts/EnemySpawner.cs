using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyprefab;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] float spawnDistance = 10f;
    Vector2 screenBounds;
    Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0 :
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + spawnDistance);
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - spawnDistance);
                break;
            case 2:
                spawnPos = new Vector2(Random.Range(-screenBounds.y, screenBounds.y), screenBounds.x + spawnDistance);
                break;
            case 3:
                spawnPos = new Vector2(Random.Range(-screenBounds.y, screenBounds.y), -screenBounds.x - spawnDistance);
                break;
        }
        Instantiate(enemyprefab, spawnPos, transform.rotation);
        Invoke("SpawnEnemy", spawnTime);
    }
}
