using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBossHealthBar : MonoBehaviour
{
    private float maxHealth = Data.alienBossHealth;
    public static float health;
    public GameObject HealthBar;

    public Animator animator;

    public GameObject backToBase;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.transform.localScale = new Vector3(GetHealthPercent(), 1);
        CheckForDeath();
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return (float)health / maxHealth;
    }

    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > maxHealth) health = maxHealth;
    }

    void CheckForDeath()
    {
        if (GetHealth() <= 0f)
        {
            animator.SetBool("Dead", true);
            backToBase.SetActive(true);

        }
    }
}

