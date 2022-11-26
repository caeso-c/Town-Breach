using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    // create public method that reduces hit points by amount of damage
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken"); // will broadcast this message to any of the scripts attached to enemy and call all OnDamageTaken methods
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
