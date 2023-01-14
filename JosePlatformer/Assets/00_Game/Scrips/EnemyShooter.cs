using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Bullet projectilePrefab; // The prefab for the projectile
    public Transform firePoint; // The point at which the projectile will be instantiated
    public float fireRate = 1f; // The rate at which the enemy will fire projectiles, in seconds
    public float fireRange = 10f; // The range at which the enemy will start firing at the player, in meters

    private GameObject player; // A reference to the player game object
    private float nextFireTime; // The time at which the enemy can next fire a projectile
    Animator myAnimator;




    void Start()
    {
        // Find the player game object using the "Player" tag
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // If the player is within range and it is time to fire, shoot a projectile
        if (Vector2.Distance(transform.position, player.transform.position) < fireRange && Time.time >= nextFireTime)
        {
            if (GameManager.instance.gameEnded) return;
            FireProjectile();
            FindObjectOfType<AudioManager>().Play("Sniper");
        }
    }

    void FireProjectile()
    {
        // Instantiate a new projectile at the fire point
        Bullet projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.SetBullet(-GetDirection(out bool isLeft), isLeft);



        // Set the next time the enemy can fire a projectile
        nextFireTime = Time.time + fireRate;
    }
    Vector2 GetDirection(out bool isLeft)
    {
        Vector2 returnValue = transform.position - player.transform.position;
        returnValue.Normalize();
        if (returnValue.x < 0)
        {
            isLeft = true;

        }
        else
        {
            isLeft = false;
        }
        return returnValue;
    }

   
}
