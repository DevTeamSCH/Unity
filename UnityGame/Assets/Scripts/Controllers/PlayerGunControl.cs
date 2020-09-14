using System.Collections;
using UnityEngine;

public class PlayerGunControl : MonoBehaviour
{
    public int damage = 10;
    public float range = 40f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    void Start()
    {
        StartCoroutine(Reload());
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading) return;
        if(currentAmmo<=0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
      
        
    }
    private void OnEnable()
    {
        isReloading = false;
    }
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        currentAmmo--;
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
