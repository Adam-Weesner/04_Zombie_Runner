using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Health), typeof(DeathHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons = null;
    [SerializeField] private DisplayDamage displayDamage = null;
    private int currIndex;
    private InGameUI inGameUI = null;
    private Health health = null;

    private void Start()
    {
        inGameUI = FindObjectOfType<InGameUI>();
        health = GetComponent<Health>();
        UpdateUI();

        if (weapons.Length > 0)
        {
            weapons[0].SetActive(true);
        }
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            ProcessWeaponSwapKey();
            ProcessWeaponSwapScroll();
        }
    }

    private void ProcessWeaponSwapKey()
    {
        if (CrossPlatformInputManager.GetButtonDown("Weapon1"))
        {
            weapons[currIndex].SetActive(false);
            currIndex = 0;
            weapons[currIndex].SetActive(true);
        }
        else if (CrossPlatformInputManager.GetButtonDown("Weapon2"))
        {
            weapons[currIndex].SetActive(false);
            currIndex = 1;
            weapons[currIndex].SetActive(true);
        }
        else if (CrossPlatformInputManager.GetButtonDown("Weapon3"))
        {
            weapons[currIndex].SetActive(false);
            currIndex = 2;
            weapons[currIndex].SetActive(true);
        }
    }


    private void ProcessWeaponSwapScroll()
    {
        if (CrossPlatformInputManager.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            weapons[currIndex].SetActive(false);
            currIndex++;

            if (currIndex >= weapons.Length)
            {
                currIndex = 0;
            }

            weapons[currIndex].SetActive(true);
        }
        else if (CrossPlatformInputManager.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            weapons[currIndex].SetActive(false);
            currIndex--;

            if (currIndex < 0)
            {
                currIndex = weapons.Length-1;
            }

            weapons[currIndex].SetActive(true);
        }
    }

    private void OnDamageTaken()
    {
        UpdateUI();
        ShowDamageUI();
    }

    private void ShowDamageUI()
    {
        if (!displayDamage) { return; }
        displayDamage.gameObject.SetActive(false);
        displayDamage.gameObject.SetActive(true);
    }

    private void UpdateUI()
    {
        if (!health || !inGameUI) { return; }
        inGameUI.SetHealth(health.GetHealth());
    }

    private void Die()
    {
        var deathHandler = GetComponent<DeathHandler>();
        if (!deathHandler) { return; }
        deathHandler.OnDeath();
    }
}
