using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image Blue;
    public Image Green;

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

    void DealDamage()
    {
        if(Blue == null || Green == null)
        {
            Debug.LogWarning("Armor bar and/or health bar are not assigned in the Inspector");
            return;
        }

        float remainingDamage = damage;
        if (Blue.fillAmount > 0)
        {
            if (Blue.fillAmount >= remainingDamage)
            {
                Blue.fillAmount -= remainingDamage;
                remainingDamage = 0;
            }
            else
            {
                remainingDamage -= Blue.fillAmount;
                Blue.fillAmount = 0;
            }
        }
        if(remainingDamage > 0)
        {
            Green.fillAmount = Mathf.Max(Green.fillAmount - remainingDamage, 0);
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