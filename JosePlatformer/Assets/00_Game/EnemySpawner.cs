using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTime;
    public Transform[] SpawnPoints;
    [SerializeField] Enemy enemy;
    [SerializeField] int maxEnemyCount = 5;
    int enemyCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnTime);

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if (enemyCount < maxEnemyCount)
            {
                Debug.Log("Spawning at" + SpawnPoints[i].name);
                Enemy newEnemy = Instantiate(enemy, SpawnPoints[i].position, Quaternion.identity);
                newEnemy.SetEnemy(this);
                enemyCount++;

            }


        }
        StartCoroutine(SpawnEnemy());
    }

    public void EnemyDown()
    {
        enemyCount--;
    }
}
