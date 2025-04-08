using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_IronSword : MonoBehaviour, IUsable
{
    public Transform Enemy;
    public int attackDamage = 25;
    float attackCooldown = 2.5f;
    float attackRange = 1.5f;
    float timer;

    public void use()
    {
        swingSword();
    }
    internal void swingSword()
    {
        Debug.Log("Swinging sword!");

        // check the killzone
        Collider[] victims = Physics.OverlapSphere(transform.position + (2* transform.forward), 0.5f);

        IHealth damageable = victims[0].GetComponent<IHealth>();

        if (damageable != null)
        {
            damageable.takeDamage(attackDamage);
        }

    }

    private void AttackEnemy()
    {
        print("Attacking!");
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, attackRange))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                timer -= Time.deltaTime;
                if (timer < 0)
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
    }
}
