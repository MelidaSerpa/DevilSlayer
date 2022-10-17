using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    [SerializeField]
    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy current health: " + currentHealth);

        //Play hurt Anim
        anim.SetBool("Hurt", true);

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        //Die anim.
        anim.SetBool("Dead", true);
        //Disable Enemy.
        Debug.Log("Enemy died!!!");
    }
}
