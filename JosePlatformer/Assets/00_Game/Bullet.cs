using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] bool isEnemy = false;
    [SerializeField] bool wasShot = false;



    public float bulletTime = 8;

    [SerializeField] int bulletDamage = 50;


    //Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", bulletTime);

    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void SetBullet(Vector2 direction, bool flipBullet)
    {

        gameObject.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        if (flipBullet)
        {
            Vector3 Scale = gameObject.transform.localScale;
            Scale.x *= -1;
            gameObject.transform.localScale = Scale;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (isEnemy)
    //    {
    //        collision.gameObject.TryGetComponent(out PlayerHealth player);

    //        if (player != null)

    //        {
    //            player.GotHit(bulletDamage);

    //            if (wasShot) Destroy(gameObject);
    //        }
    //    }
    //    else
    //    {
    //        collision.gameObject.TryGetComponent(out ITakeDamage damagedObject);

    //        if (damagedObject != null)

    //        {
    //            damagedObject.TakeDamage(bulletDamage);

    //            if (wasShot) Destroy(gameObject);
    //        }

    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnemy)
        {
            collision.gameObject.TryGetComponent(out PlayerHealth player);

            if (player != null)

            {
                player.GotHit(bulletDamage);

                if (wasShot) Destroy(gameObject);
            }
        }
        else
        {
            collision.gameObject.TryGetComponent(out ITakeDamage damagedObject);

            if (damagedObject != null)

            {
                damagedObject.TakeDamage(bulletDamage);

                if (wasShot) Destroy(gameObject);
            }

        }
    }
}
