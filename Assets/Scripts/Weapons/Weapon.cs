using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash = null;
    [SerializeField] private GameObject hitEffect = null;
    [Header("Weapon Type")]
    [SerializeField] private AmmoTypes type = AmmoTypes.Pistol;
    [SerializeField] [Range(0, 100)] private uint damage = 1;
    [SerializeField] private float range = 100.0f;
    [SerializeField] private float secondsBetweenShots = 0.1f;
    [SerializeField] private bool canAutoFire = false;
    private Ammo ammo;
    private bool canShoot = true;
    private InGameUI inGameUI = null;

    private void Start()
    {
        ammo = GetComponentInParent<Ammo>();
        inGameUI = FindObjectOfType<InGameUI>();
        UpdateUI();
    }

    private void OnEnable()
    {
        canShoot = true;
        UpdateUI();
    }

    void Update()
    {
        if (canShoot)
        {
            if (canAutoFire)
            {
                if (Input.GetButton("Fire1"))
                {
                    StartCoroutine(Shoot());
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    StartCoroutine(Shoot());
                }
            }
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (ammo.GetAmmo(type) > 0)
        {
            ammo.ReduceAmmo(type);
            UpdateUI();
            ProcessRaycast();
            PlayMuzzleFlash();
        }

        yield return new WaitForSeconds(secondsBetweenShots);
        canShoot = true;
    }

    private void UpdateUI()
    {
        if (!inGameUI) { return; }
        inGameUI.SetAmmo(ammo.GetAmmo(type));
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            var health = hit.collider.GetComponent<Health>();

            if (health)
            {
                health.Damage(damage);
            }

            CreateHitImpact(hit);
        }
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
