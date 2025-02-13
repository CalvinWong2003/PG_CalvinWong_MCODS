using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public float speed = 3f;
    public float damage = 10f;
    public float attackRange = 1f;
    private float attackCooldown = 1.0f;
    private float nextAttackTime = 0f;
    public float currentHealth;
    public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        if(Player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if(playerObj != null)
            {
                Player = playerObj.transform;
            }
            else
            {
                Debug.LogWarning("Player Not found! Ensure player GameObject is tagged as 'Player'");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);

            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
            if(distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
            {
                DealDamage();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    private void DealDamage()
    {
        PlayerHealthArmor playerHealth = Player.GetComponent<PlayerHealthArmor>();

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage. Remaining health: " + currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy down!");
        //Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            
        }
    }
}
