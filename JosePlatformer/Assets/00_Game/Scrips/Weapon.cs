using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Weapon : MonoBehaviour
{


    public Bullet projectilePrefab;
    [SerializeField]Animator myAnimator;
    [SerializeField] PlayerController player;
    [SerializeField] PlayerHealth myHealth;
    private void Start()
    {
        player = GetComponent<PlayerController>();
        myHealth = GetComponent<PlayerHealth>();
    }
    public void OnFire()
    {
        if (myHealth.death) return;
        // Create a new projectile
        Bullet projectile = Instantiate(projectilePrefab);

        // Set the position and velocity of the projectile
        projectile.transform.position = transform.position;

        if (player.isFlipped)
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
