using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float TimeBetweenSpawn;
    [SerializeField] private GameObject obstaclePrefab;
    private float SpawnTime;
    [SerializeField] public List<GameObject> gameObjects= new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTime && gameObjects.Count < 3)
        {
            SpawnObstacle();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }

    void SpawnObstacle ()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        GameObject obstacleInstance = Instantiate(obstaclePrefab, new Vector3(x, y, 0), transform.rotation);
        gameObjects.Add(obstacleInstance);
    }
}
