using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent agent;
    public float speed = 3f;
    public float damage = 10f;
    public float attackRange = 1f;
    private float attackCooldown = 1.0f;
    private float nextAttackTime = 0f;
    
    public float currentHealth;
    public float maxHealth = 100f;

    public int scoreValue = 20;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);

            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
            if(distanceToPlayer <= attackRange)
            {
                AttackPlayer();
                nextAttackTime = Time.time;
            }
        }
    }

    public void AttackPlayer()
    {
        PlayerHealthArmor playerStats = Player.GetComponent<PlayerHealthArmor>();
        if(playerStats != null)
        {
            playerStats.TakeDamage(damage);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameController.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            float bulletDamage = 30f;

            Bullet bullet = other.GetComponent<Bullet>();

            if (bullet != null)
            {
                bulletDamage = bullet.damage;
            }
            TakeDamage(bulletDamage);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Sword"))
        {
            float swordDamage = 20f;

            CW_IronSword sword = other.GetComponent<CW_IronSword>();
            if(sword != null)
            {
                swordDamage = sword.attackDamage;
            }
            TakeDamage(swordDamage);
        }
    }
}