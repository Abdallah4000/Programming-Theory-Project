using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private float xSpawn =4.7f ;
    private float ySpawn = .25f;
    private float zSpawn = 40f;
    private float delay = 2f;
    private float spawnRate = .7f;
    private int difficulty = 1;
    void Start()
    {
        Invoke("EnemySpawn",delay);
        
    }


    void EnemySpawn()
    {
        difficulty++;

        if(difficulty % 25 == 0 && spawnRate >.1)
        {
            spawnRate -= .05f;
        }

        float xPos = Random.Range(-xSpawn , xSpawn);
        Vector3 randomPos = new Vector3(xPos,ySpawn,zSpawn);
        Instantiate(enemy,randomPos,enemy.transform.rotation);
        Invoke("EnemySpawn",spawnRate);

    }
}
