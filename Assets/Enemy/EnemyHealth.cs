using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    // create public method that reduces hit points by amount of damage
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken"); // will broadcast this message to any of the scripts attached to enemy and call all OnDamageTaken methods
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // prevents enemy from retriggering death animation after being shot again
        isDead = true;
        GetComponent<Animator>().SetTrigger("Death");
    }
}
