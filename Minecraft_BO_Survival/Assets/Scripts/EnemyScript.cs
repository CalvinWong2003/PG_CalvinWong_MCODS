using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public float speed = 3f;
    public float damage = 10f;
    public float attackRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            Vector3 direction = (Player.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);

            float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
            if(distanceToPlayer <= attackRange)
            {
                DealDamage();
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
}
