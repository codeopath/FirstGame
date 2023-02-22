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
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private WarriorHandler warriorHandler;
    private float SpawnTime;
    [SerializeField] public List<GameObject> gameObjects= new List<GameObject>();
    [SerializeField] private GameObject obstacleInstance;
    private float bulletSpawnTime;
    [SerializeField] private float TimeBetweenSpawnForBullet;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTime && gameObjects.Count < 3)
        {
            SpawnObstacle();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
        if (Time.time > bulletSpawnTime)
        {
            bulletSpawnTime = Time.time + TimeBetweenSpawnForBullet;
            bsg();
        }
    }

    void SpawnObstacle ()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        obstacleInstance = Instantiate(obstaclePrefab, new Vector3(x, y, 0), transform.rotation);
        gameObjects.Add(obstacleInstance);
       
    }

    void bsg ()
    {
        gameObjects.ForEach(a =>
        {
            ThrowBullet(a);
        });

    }
    private void ThrowBullet(GameObject a)
    {
        GameObject WarriorInstance = warriorHandler.WarriorInstance;
        GameObject BallInstance = Instantiate(bulletPrefab, a.GetComponent<Rigidbody2D>().position, Quaternion.identity);
        Rigidbody2D rigidbody2D = BallInstance.GetComponent<Rigidbody2D>();
        Vector3 obstaclePostion = a.GetComponent<Rigidbody2D>().position;
        Vector3 warriorPosition = WarriorInstance.GetComponent<Rigidbody2D>().position;
        rigidbody2D.velocity = new Vector3(warriorPosition.x - obstaclePostion.x, warriorPosition.y - obstaclePostion.y);
    }
}
