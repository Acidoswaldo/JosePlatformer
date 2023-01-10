using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GotHit(int DamageAmount)
    {
        currentHealth -= DamageAmount;
        PlayerDeath();
    }
}
