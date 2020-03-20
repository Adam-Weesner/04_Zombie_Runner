using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Ammo : MonoBehaviour
{
    [SerializeField] private uint pistolAmmo = 10;
    [SerializeField] private uint carbineAmmo = 10;
    [SerializeField] private uint shotgunAmmo = 10;

    public uint GetAmmo(AmmoTypes ammoType)
    {
        switch (ammoType)
        {
            case AmmoTypes.PISTOL:
                return pistolAmmo;
            case AmmoTypes.CARBINE:
                return carbineAmmo;
            case AmmoTypes.SHOTGUN:
                return shotgunAmmo;
            default:
                return carbineAmmo;
        }
    }

    public void AddAmmo(AmmoTypes ammoType, uint ammo)
    {
        switch (ammoType)
        {
            case AmmoTypes.PISTOL:
                pistolAmmo += ammo;
                break;
            case AmmoTypes.CARBINE:
                carbineAmmo += ammo;
                break;
            case AmmoTypes.SHOTGUN:
                shotgunAmmo += ammo;
                break;
            default:
                break;
        }
    }

    public void ReduceAmmo(AmmoTypes ammoType)
    {
        switch (ammoType)
        {
            case AmmoTypes.PISTOL:
                pistolAmmo--;
                break;
            case AmmoTypes.CARBINE:
                carbineAmmo--;
                break;
            case AmmoTypes.SHOTGUN:
                shotgunAmmo--;
                break;
            default:
                break;
        }
    }
}
