using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    Transform Player;
    float speed = 3f;
    float damage = 10f;
    float attackRange = 1f;
    private float attackCooldown = 3.0f;
    float timer = 0;
    
    float currentHealth;
    float maxHealth = 100f;
    NavMeshAgent navigate;
    public int scoreValue = 20;
    // Start is called before the first frame update
    void Start()
    {
        navigate = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        CharacterControllerScript thePlayerScript = FindObjectOfType<CharacterControllerScript>();
        Player = thePlayerScript.transform;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(Player != null)
        {
            //transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            navigate.SetDestination(Player.position);
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
                playerStats.UpdateBars();
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
        if (other.CompareTag("Sniper Bullet"))
        {
            float bulletDamage = 100f;

            SniperBullet sniperBullet = other.GetComponent<SniperBullet>();

            if (sniperBullet != null)
            {
                bulletDamage = sniperBullet.damage;
            }
            TakeDamage(bulletDamage);
            Destroy(other.gameObject);
        }
    }
}