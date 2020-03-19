using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private uint ammoCount = 10;

    public uint GetAmmo()
    {
        return ammoCount;
    }

    public void ReduceAmmo()
    {
        ammoCount--;
    }
}
