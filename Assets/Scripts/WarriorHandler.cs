using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorHandler : MonoBehaviour
{
    [SerializeField] private GameObject warriorPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float TimeBetweenSpawn;
    private float SpawnTime;
    public GameObject WarriorInstance;

    public ObstacleSpawner obstacleSpawner;
    // Start is called before the first frame update
    void Start()
    {
        WarriorInstance = Instantiate(warriorPrefab, new Vector3(x, y, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTime)
        {
            SpawnTime = Time.time + TimeBetweenSpawn;
            ThrowBullet();
        }
    }

    private void ThrowBullet()
    {
        GameObject obstacle = getCorrectObstacleToHit(obstacleSpawner.gameObjects);
        Vector3 obstaclePostion = obstacle.GetComponent<Rigidbody2D>().position;
        Vector3 warriorPosition = WarriorInstance.GetComponent<Rigidbody2D>().position;
        GameObject BallInstance = Instantiate(bulletPrefab, WarriorInstance.GetComponent<Rigidbody2D>().position, Quaternion.identity);
        Rigidbody2D rigidbody2D = BallInstance.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector3(obstaclePostion.x - warriorPosition.x, obstaclePostion.y - warriorPosition.y);
    }

    private GameObject getCorrectObstacleToHit(List<GameObject> gameObjects)
    {
        gameObjects.RemoveAll(gameObject => !gameObject.activeSelf);
        return gameObjects[0];
    }
}
