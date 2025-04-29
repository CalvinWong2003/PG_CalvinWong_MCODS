using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour,IHealth
{
    Transform Player;
    int damage = 10;
    float attackRange = 1.5f;
    float attackCooldown = 5.0f;
    float timer = 0;

    bool isHit = false;
    private Color defaultColor;
    private Color isHitColor = Color.red;
    private float colorDuration = 0.5f;
    float currentHealth;
    float maxHealth = 100f;
    NavMeshAgent navigate;
    int scoreValue = 20;

    Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        navigate = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        CharacterControllerScript thePlayerScript = FindObjectOfType<CharacterControllerScript>();
        Player = thePlayerScript.transform;
        myRenderer.material.color = defaultColor;
    }
    // Update is called once per frame
    void Update()
    {
      
        timer -= Time.deltaTime;
        if(Player != null)
        {
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
        timer -= Time.deltaTime;
        print("Attacking");
        if (timer < 0)
        {
            print("Hitting");
            IHealth victim = Player.GetComponent<IHealth>();
            if (victim != null)
            {
                victim.takeDamage(damage);
            }
            timer = attackCooldown;
        }
    }
    void Die()
    {
        GameController.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        isHit = true;
        myRenderer.material.color = isHitColor;
        timer += Time.deltaTime;
        if(timer >= colorDuration)
        {
            isHit = false;
            myRenderer.material.color = defaultColor;
        }

        if(currentHealth <= 0)
        {
            Die();
            Destroy(gameObject);
        }
    }
}