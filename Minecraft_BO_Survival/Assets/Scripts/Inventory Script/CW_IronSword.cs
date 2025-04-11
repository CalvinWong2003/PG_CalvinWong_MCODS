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
}
