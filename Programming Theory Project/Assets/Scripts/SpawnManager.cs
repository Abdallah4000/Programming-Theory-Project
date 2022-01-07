using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemy = new List<GameObject>();

    private float xSpawn =4.7f ;
    private float ySpawn = .25f;
    private float zSpawn = 98f;
    private float delay = 2f;
    private float spawnRate = .7f;
    private int difficulty = 1;
    private int level;
    void Start()
    {
        level = DataSaver.instance.level;
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
        Instantiate(enemy[level],randomPos,enemy[level].transform.rotation);
        Invoke("EnemySpawn",spawnRate);

    }
}
