using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : Pickup
{
    [SerializeField] private float restoreAmount = 1.0f;

    protected override void PlayerPickedUp(GameObject player)
    {
        Flashlight flashlight = player.GetComponentInChildren<Flashlight>();

        if (!flashlight) { return; }

        flashlight.RestoreLightIntensity(restoreAmount * 1.2f);
        flashlight.RestoreLightAngle(restoreAmount * 40.0f);

        Destroy(gameObject);
    }
}
