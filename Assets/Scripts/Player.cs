using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Health), typeof(DeathHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons = null;
    private int currIndex;

    private void Start()
    {
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
}
