using RL.Managers;
using RL.Player;
using RL.UI;
using System.Collections;
using UnityEngine;

namespace RL.Combat
{
    public class PlayerGunControl : MonoBehaviour
    {
        public int damage = 10;
        public float range = 40f;

        public Camera fpsCam;
        public ParticleSystem muzzleFlash;
        public GameObject impactEffect;
        public WeaponUI ui;

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
            if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
                return;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }


        }
        private void OnEnable()
        {
            isReloading = false;
            ui.UpdateAmmo(currentAmmo, maxAmmo);
        }
        IEnumerator Reload()
        {
            isReloading = true;
            yield return new WaitForSeconds(reloadTime);
            currentAmmo = maxAmmo;
            isReloading = false;
            ui.UpdateAmmo(currentAmmo, maxAmmo);
        }

        private void Shoot()
        {
            muzzleFlash.Play();
            currentAmmo--;
            RaycastHit hit = GameManager._instance.viewSystem.GetHit();
            ui.UpdateAmmo(currentAmmo, maxAmmo);
            // if (Physics.Raycast(fpsCam.transform.position+ fpsCam.transform.forward*0.1f, fpsCam.transform.forward, out hit, range))
            if (hit.transform != null && GameManager._instance.viewSystem.GetDistanece() <= range)
            {
                Debug.Log("poof " + GameManager._instance.viewSystem.GetDistanece());
                HealthController hc = hit.transform.GetComponent<HealthController>();
                if (hc != null)
                {
                    Debug.Log("loli");
                    hc.TakeDamage(damage);

                }
                GameObject effect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                effect.GetComponent<DecalDestroyer>().lifeTime = 0.5f;
                effect.transform.SetParent(hit.transform);

            }

        }
    }
}