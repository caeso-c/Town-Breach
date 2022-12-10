using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    Win win;

    public bool isDead = false;

    void Start()
    {
        win = FindObjectOfType<Win>();
    }

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
        win.enemyCounter--;
        GetComponent<Animator>().SetTrigger("Death");
    }
}
