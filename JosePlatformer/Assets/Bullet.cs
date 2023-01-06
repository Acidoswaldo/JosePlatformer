using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
  
    public float bulletTime = 8;


    //Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet",bulletTime);

    }
void DestroyBullet()
{
Destroy(gameObject); 
}

}
