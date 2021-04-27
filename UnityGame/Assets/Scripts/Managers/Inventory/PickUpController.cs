using System;
using UnityEngine;

namespace RL.Managers
{
    public class PickUpController : MonoBehaviour
    {
        public Item item;

        private void Start()
        {
            gameObject.tag = "Pickable";
        }

        public bool PickItUp(float distance, ref Item pick)
        {
            if (distance <= item.pickUpDistane)
            {
                pick = item;
                Destroy(this.gameObject);
                return true;
            }

            return false;
        }
    }
}