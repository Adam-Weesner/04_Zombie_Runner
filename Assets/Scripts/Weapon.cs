using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float range = 100.0f;
    [SerializeField] [Range(0, 100)] private int damage = 1;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            print(name + " hit " + hit.collider.name + "!");
            var health = hit.collider.GetComponent<Health>();

            if (health)
            {
                health.Damage(damage);
            }
        }
    }
}
