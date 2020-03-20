using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [System.Serializable]
    private class AmmoSlots
    {
        public AmmoTypes ammoType = AmmoTypes.Pistol;
        public uint ammoCount = 10;
    }

    [SerializeField] AmmoSlots[] ammoSlots = null;

    public uint GetAmmo(AmmoTypes ammoType)
    {
        foreach (AmmoSlots slot in ammoSlots)
        {
            if (ammoType == slot.ammoType)
            {
                return slot.ammoCount;
            }
        }
        return 0;
    }

    public void AddAmmo(AmmoTypes ammoType, uint ammo)
    {
        foreach (AmmoSlots slot in ammoSlots)
        {
            if (ammoType == slot.ammoType)
            {
                slot.ammoCount += ammo;
            }
        }
    }

    public void ReduceAmmo(AmmoTypes ammoType)
    {
        foreach (AmmoSlots slot in ammoSlots)
        {
            if (ammoType == slot.ammoType)
            {
                slot.ammoCount--;
            }
        }
    }
}
