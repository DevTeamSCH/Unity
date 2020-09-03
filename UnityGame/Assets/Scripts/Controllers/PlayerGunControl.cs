using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    public float range = 40f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            HealthController hc = hit.transform.GetComponent<HealthController>();
            if (hc != null)
            {
                hc.TakeDamage(damage);
                
            }
            GameObject effect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            effect.GetComponent<DecalDestroyer>().lifeTime = 0.5f;
            effect.transform.SetParent(hit.transform);

        }

    }
}
