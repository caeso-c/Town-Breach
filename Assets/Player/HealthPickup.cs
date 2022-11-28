using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerHealth.hitPoints < 100f)
        {
            playerHealth.IncreaseHealth();
            Destroy(gameObject);
        }
    }
}
