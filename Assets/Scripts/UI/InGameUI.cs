using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI ammo;

    public void SetHealth(int newHealth)
    {
        health.text = "Health: " + newHealth;
    }

    public void SetAmmo(uint newAmmo)
    {
        ammo.text = "Ammo: " + newAmmo;
    }
}
