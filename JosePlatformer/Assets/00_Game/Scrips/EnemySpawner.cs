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
    int maxCountModifier;
    [SerializeField] int scoreEnemyIncrease=5;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemy());
    }

    //IEnumerator SpawnEnemy()
    //{
    //    yield return new WaitForSeconds(spawnTime);

    //    for (int i = 0; i < SpawnPoints.Length; i++)
    //    {
    //        if (enemyCount < maxEnemyCount)
    //        {
    //            Debug.Log("Spawning at" + SpawnPoints[i].name);
    //            Enemy newEnemy = Instantiate(enemy, SpawnPoints[i].position, Quaternion.identity);
    //            newEnemy.SetEnemy(this);
    //            enemyCount++;

    //        }


    //    }
    //    StartCoroutine(SpawnEnemy());
    //}

    public void EnemyDown()
    {
        enemyCount--;
    }

    void SpawnEnemies()
    {
        if (enemyCount < maxEnemyCount + maxCountModifier)
        {
            Transform currentSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            Enemy newEnemy = Instantiate(enemy, currentSpawnPoint.position, Quaternion.identity);
            newEnemy.SetEnemy(this);
            enemyCount++;

        }

    }
    private void Update()
    {
        SpawnEnemies();
        CheckMaxCount();
    }

    void CheckMaxCount()
    {
        maxCountModifier = GameManager.instance.GetScore()/scoreEnemyIncrease;
    }
}
