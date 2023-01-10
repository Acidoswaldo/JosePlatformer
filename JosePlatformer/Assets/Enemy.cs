using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    PlayerController player;
    [SerializeField] float speed = 10f;
    [SerializeField] float distanceToPlayer=3f;
    [SerializeField] int enemyHealth = 100;
    EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveToPlayer();

    }

    void MoveToPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position)>distanceToPlayer)
        {
            Vector3 position = transform.position;
            position = Vector3.MoveTowards(position, player.transform.position, speed * Time.deltaTime);
            transform.position = position;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        Debug.Log("TookDamage");
        if(enemyHealth<=0)
        {
            enemySpawner.EnemyDown();
            Destroy(gameObject);

        }
        
    }

    public void SetEnemy (EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;

    }

}
