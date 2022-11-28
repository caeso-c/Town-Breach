using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera; // variable for camera
    [SerializeField] float range = 100f; // how far raycast goes
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect; // using game object for particle hit fx so we can spawn and destroy it
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType; // public enum visible on each weapon - passes through Ammo methods
    [SerializeField] float timeBetweenShots;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;

    private void OnEnable() // when this instance of this class is enabled..
    {
        canShoot = true; // reenable player to shoot when they switch weapon
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit; // stores info of what the raycast hit

        // executes raycast and returns bool - did you hit something yes or no
        // position raycast shoots from, direction shot goes, what did the raycast hit, and how far did it go
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>(); // if we hit something, access enemy health component
            if (target == null) return; // avoid null when shooting an object without enemy health script attached to it
            target.TakeDamage(damage); // run take damage method in target that inflicts damage to enemy
        }
        else
        {
            return; // avoids null when shooting nothing
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 5f);
    }
}
