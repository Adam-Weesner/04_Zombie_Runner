using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] private AmmoTypes ammoType = AmmoTypes.Pistol;
    [SerializeField] private uint ammoCount = 5;

    protected override void PlayerPickedUp(GameObject player) 
    {
        player.GetComponent<Ammo>().AddAmmo(ammoType, ammoCount);
        Destroy(gameObject);
    }
}
