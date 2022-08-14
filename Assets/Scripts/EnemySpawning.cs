using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject soldier;
    float spawningTime;

    void Start()
    {
        spawningTime = 10;
    }


    void Update()
    {
        spawningTime -= Time.deltaTime;

        if (spawningTime <= 0)
        {
            EnemySpawn();
            EnemySpawn();
            spawningTime = 10;
        }
    }

    void EnemySpawn()
    {
        int spawnX = Random.Range(200, 800);
        int spawnZ = Random.Range(200, 800);
        Instantiate(soldier, new Vector3(spawnX, 0, spawnZ), Quaternion.identity);
    }
}
