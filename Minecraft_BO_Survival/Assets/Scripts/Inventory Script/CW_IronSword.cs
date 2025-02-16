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

    [Tooltip("Origin of attack and in forward direction")]
    public Transform Player;

    [Tooltip("To detect if the enemy is in range")]
    public LayerMask enemyLayer;

    public void use()
    {
        swingSword();
    }
    internal void swingSword()
    {
        Debug.Log("Swinging sword!");
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyScript>()?.TakeDamage(attackDamage);
        }
    }
}
