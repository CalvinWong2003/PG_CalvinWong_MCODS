using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_IronSword : MonoBehaviour, IUsable
{
    public Transform Enemy;

    [Tooltip("Amount of damage the Player deals with the iron sword")]
    public int attackDamage = 25;

    [Tooltip("Cooldown between attacks")]
    public float attackCooldown = 2.5f;

    [Tooltip("Attack range of iron sword")]
    public float attackRange = 1.5f;

    float timer = 0;

    public void use()
    {
        swingSword();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            swingSword();
        }
    }
    internal void swingSword()
    {
        timer -= Time.deltaTime;
        Debug.Log("Swinging sword!");
        float distanceToEnemy = Vector3.Distance(transform.position, Enemy.position);
        if (distanceToEnemy <= attackRange)
        {
            AttackEnemy();
        }
    }

    private void AttackEnemy()
    {
        print("Attacking!");
        if(timer < 0)
        {
            EnemyScript enemyStats = Enemy.GetComponent<EnemyScript>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(attackDamage);
            }
            timer = attackCooldown;
        }
    }
}
