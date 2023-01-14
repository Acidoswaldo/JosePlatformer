using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Bullet projectilePrefab;
    [SerializeField]Animator myAnimator;

    public void OnFire()
    {
        // Create a new projectile
        Bullet projectile = Instantiate(projectilePrefab);

        // Set the position and velocity of the projectile
        projectile.transform.position = transform.position;
        if (transform.localScale.x < 0)
        {
            myAnimator.SetTrigger("isShooting");
            projectile.SetBullet(-transform.right, true);
            FindObjectOfType<AudioManager>().Play("Beam");
        }
        else
        {
            projectile.SetBullet(transform.right, false);
            myAnimator.SetTrigger("isShooting");
            FindObjectOfType<AudioManager>().Play("Beam");
        }

    }
}
