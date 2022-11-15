using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target; // PlayerHealth variable to 
    [SerializeField] float damage = 10f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>(); // target is now PlayerHealth - avoids dragging Player into script on enemy object
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage); // passing damage parameter to player health TakeDamage method
        Debug.Log("BOOM");
    }
}
