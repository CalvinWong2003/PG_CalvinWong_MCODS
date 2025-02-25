using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_IronSword : MonoBehaviour, IUsable
{
    [Tooltip("Amount of damage the Player deals with the iron sword")]
    public int attackDamage = 25;

    [Tooltip("Cooldown between attacks")]
    public float attackCooldown = 1.5f;

    [Tooltip("Attack range of iron sword")]
    public float attackRange = 1.5f;

    public void use()
    {
        swingSword();
    }
    internal void swingSword()
    {
        Debug.Log("Swinging sword!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyScript enemyHealth = other.GetComponent<EnemyScript>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }
}
