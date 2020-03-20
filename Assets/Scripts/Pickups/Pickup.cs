using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            PlayerPickedUp(other.gameObject);
        }
    }

    protected virtual void PlayerPickedUp(GameObject player) { }
}
