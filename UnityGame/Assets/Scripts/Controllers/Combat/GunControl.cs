using RL.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RL.Combat
{
    public class GunControl : MonoBehaviour
    {
        public float damage = 5;
        public float range = 10f;
        public float turnSpeed = 10f;

        public float fireRate = 1f;
        private float fireCountDown = 0f;

        private string playerTag = "Player";

        private Transform target;
        public GameObject bulletPrefab;
        public Transform bulletStartPoint;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        // Update is called once per frame
        //TODO: ez sokkal elegánsabb lene coroutine-nal
        void Update()
        {
            if (target == null) return;

            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1 / fireRate;
            }
            fireCountDown -= Time.deltaTime;

        }
        private void OnTriggerEnter(Collider other)
        {
            Shoot();
        }

        void Shoot()
        {
            GameObject bulletGO = Instantiate(bulletPrefab);
            bulletGO.transform.position = bulletStartPoint.position;
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetTarget(target);
            }
        }

        void UpdateTarget()
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(playerTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestTarget = null;
            foreach (var target in targets)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                var san = target.GetComponent<SanityController>();
                
                if (distance*san.SanityPercentage < shortestDistance) //the less the sanity, the further we see
                {
                    shortestDistance = distance;
                    nearestTarget = target;
                }
            }
            if (nearestTarget != null && shortestDistance <= range)
            {
                target = nearestTarget.transform;
            }
            else target = null;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}