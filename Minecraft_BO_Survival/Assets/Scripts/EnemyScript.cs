using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public float speed = 3f;
    public float damage = 10f;
    public float attackRange = 1f;
    private float attackCooldown = 3.0f;
    float timer = 0;
    
    public float currentHealth;
    public float maxHealth = 100f;

    public int scoreValue = 20;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);

            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
            if(distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
        }
    }

    public void AttackPlayer()
    {
        print("Attacking");
        if (timer < 0)
        {
            print("Hitting");
            PlayerHealthArmor playerStats = Player.GetComponent<PlayerHealthArmor>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
            timer = attackCooldown;
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
    }
}