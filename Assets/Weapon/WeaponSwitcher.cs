using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    [SerializeField] Canvas yellowReticleCanvas;
    [SerializeField] Canvas blueReticleCanvas;
    [SerializeField] Canvas redReticleCanvas;

    void Start()
    {
        SetWeaponActive();
        yellowReticleCanvas.enabled = true;
    }

    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();
        SetReticle();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform) // will loop through each game object under weapons parent
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
            //SetYellowReticle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
            //SetBlueReticle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
            //SetRedReticle();
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // if scroll wheel is going up
        {
            if (currentWeapon >= transform.childCount - 1) // reset scroll wheel if goes past weapon parent's child object count
            {
                currentWeapon = 0;
            }
            else // otherwise add 1 to current weapon
            {
                currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // if scroll wheel is going down
        {
            if (currentWeapon <= 0) // reset scroll wheel if goes past weapon parent's child object count
            {
                currentWeapon = transform.childCount - 1;
            }
            else // otherwise add 1 to current weapon
            {
                currentWeapon--;
            }
        }
    }

    private void SetReticle()
    {
        if (currentWeapon == 0)
        {
            SetYellowReticle();
        }
        if (currentWeapon == 1)
        {
            SetBlueReticle();
        }
        if (currentWeapon == 2)
        {
            SetRedReticle();
        }
        else
        {
            return;
        }
    }

    private void SetRedReticle()
    {
        yellowReticleCanvas.enabled = false;
        blueReticleCanvas.enabled = false;
        redReticleCanvas.enabled = true;
    }

    private void SetBlueReticle()
    {
        yellowReticleCanvas.enabled = false;
        redReticleCanvas.enabled = false;
        blueReticleCanvas.enabled = true;
    }

    private void SetYellowReticle()
    {
        blueReticleCanvas.enabled = false;
        redReticleCanvas.enabled = false;
        yellowReticleCanvas.enabled = true;
    }
}
