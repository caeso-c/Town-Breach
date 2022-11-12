using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera; // variable for camera
    [SerializeField] float range = 100f; // how far raycast goes
    [SerializeField] float damage = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit; // stores info of what the raycast hit

        // executes raycast and returns bool - did you hit something yes or no
        // position raycast shoots from, direction shot goes, what did the raycast hit, and how far did it go
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("You hit " + hit.transform.name);
            // add hit vfx

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>(); // if we hit something, access enemy health component
            if (target == null) return; // avoid null when shooting an object without enemy health script attached to it
            target.TakeDamage(damage); // run take damage method in target that inflicts damage to enemy
        }
        else
        {
            return; // avoids null when shooting nothing
        }
        
    }
}
