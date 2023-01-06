using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

      public GameObject projectilePrefab;
      [SerializeField] float bulletSpeed = 10; 

    public void OnFire()
    {
        // Create a new projectile
        GameObject projectile = Instantiate(projectilePrefab);

        // Set the position and velocity of the projectile
        projectile.transform.position = transform.position;
        if(transform.localScale.x<0)
        {
        projectile.GetComponent<Rigidbody2D>().velocity = -(transform.right) * bulletSpeed;
        Vector3 Scale = projectile.transform.localScale;
        Scale.x *= -1;
        projectile.transform.localScale = Scale;
        }
        else
        {
        projectile.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        }

    }
}
