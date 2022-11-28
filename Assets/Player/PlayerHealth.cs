using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthBar;

    public float hitPoints = 100f;

    void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        healthBar.text = hitPoints.ToString() + "%";
    }

    // create public method that reduces hit points by amount of damage
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void IncreaseHealth()
    {
        hitPoints = 100f;
    }
}
