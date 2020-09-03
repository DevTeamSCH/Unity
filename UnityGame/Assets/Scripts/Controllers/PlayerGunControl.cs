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
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            HealthController hc = hit.transform.GetComponent<HealthController>();
            if (hc != null)
            {
                hc.TakeDamage(damage);
            }
        }

    }
}
