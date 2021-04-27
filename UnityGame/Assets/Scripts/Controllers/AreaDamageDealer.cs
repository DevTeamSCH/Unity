using RL.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RL.Enemies
{
    [RequireComponent(typeof(Collider))]
    public class AreaDamageDealer : MonoBehaviour
    {

        Collider collider;
        public int damagePerSecond;
        private HealthController targetPlayer; //TODO consider if there can be multiple players?
        void Start()
        {
            collider = GetComponent<Collider>();
            StartCoroutine(DamageCoroutine());
        }

        //player arrived
        private void OnTriggerEnter(Collider other)
        {
            var t = other.GetComponent<HealthController>();
            if (t != null && t.CompareTag("Player"))
            {
                targetPlayer = t;
            }

        }

        //player left
        private void OnTriggerExit(Collider other)
        {
            if (targetPlayer != null && other.gameObject == targetPlayer.gameObject)
            {
                targetPlayer = null;
            }
        }


        private IEnumerator DamageCoroutine()
        {
            while (true)
            {
                if (targetPlayer != null) targetPlayer.TakeDamage(damagePerSecond);
                yield return new WaitForSeconds(1);
        }
        }
    }
}