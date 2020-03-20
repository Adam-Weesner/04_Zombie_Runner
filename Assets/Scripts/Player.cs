using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Health), typeof(DeathHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons = null;
    private GameObject currWeapon;

    private void Start()
    {
        if (weapons.Length > 0)
        {
            currWeapon = weapons[0];
            currWeapon.SetActive(true);
        }
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Weapon1"))
        {
            currWeapon.SetActive(false);
            currWeapon = weapons[0];
            currWeapon.SetActive(true);
        }
        else if (CrossPlatformInputManager.GetButtonDown("Weapon2"))
        {
            currWeapon.SetActive(false);
            currWeapon = weapons[1];
            currWeapon.SetActive(true);
        }
        else if (CrossPlatformInputManager.GetButtonDown("Weapon3"))
        {
            currWeapon.SetActive(false);
            currWeapon = weapons[2];
            currWeapon.SetActive(true);
        }

    }
}
