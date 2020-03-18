using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private float range = 100.0f;
    [SerializeField] [Range(0, 100)] private int damage = 1;
    [SerializeField] ParticleSystem muzzleFlash = null;
    [SerializeField] GameObject hitEffect = null;

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
        
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            var health = hit.collider.GetComponent<Health>();

            if (health)
            {
                health.Damage(damage);
            }

            CreateHitImpact(hit);
        }

        PlayMuzzleFlash();
    }

    void CreateHitImpact(RaycastHit hit)
    {
        var newHit = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(newHit, 0.1f);
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
