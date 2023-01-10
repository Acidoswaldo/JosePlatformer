using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Bullet projectilePrefab;

    public void OnFire()
    {
        // Create a new projectile
        Bullet projectile = Instantiate(projectilePrefab);

        // Set the position and velocity of the projectile
        projectile.transform.position = transform.position;
        if (transform.localScale.x < 0)
        {
            projectile.SetBullet(-transform.right, true);
        }
        else
        {
            projectile.SetBullet(transform.right, false);
        }

    }
}
