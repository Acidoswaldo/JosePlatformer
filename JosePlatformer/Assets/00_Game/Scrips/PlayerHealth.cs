using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] Animator myAnimator;
    [SerializeField] Image healthBar;
    [SerializeField] MMF_Player shaker;
    public bool death;
 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    void PlayerDeath()
    {
        if (currentHealth <= 0 && !death)
        {
            death = true;
            GameManager.instance.gameEnded = true;
            GameManager.instance.EndGame();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }
    }

    public void GotHit(int DamageAmount)
    {
        if (death) return;
        currentHealth -= DamageAmount;
        myAnimator.SetTrigger("isHurting");
        FindObjectOfType<AudioManager>().Play("Ouch");
        UpdateHealthBar();
        PlayerDeath();
        shaker.PlayFeedbacks();
    }
    void UpdateHealthBar ()
    {
        float barHealth = (float)currentHealth / (float)maxHealth;
        healthBar.fillAmount = barHealth;
    }
}
