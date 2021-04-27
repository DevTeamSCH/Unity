using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RL.Player
{

    public class TorchControl : MonoBehaviour
    {
        bool isOn = true;
        int charge;
        int maxcharge = 100;
        public GameObject lightSource;
        SanityController sanityController;
        public TextMeshProUGUI batteryText;
        // Start is called before the first frame update
        void Start()
        {
            charge = maxcharge;
            sanityController = GetComponent<SanityController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Switch();
            }
        }

        public void Switch()
        {
            if (charge > 0)
            {
                isOn = !isOn;
                sanityController.TorchOn = isOn;
                if (isOn)
                {
                    StartCoroutine(UseBattery());
                }
                lightSource.SetActive(isOn);
            }
        }

        public void Recharge()
        {
            charge = maxcharge;
        }
        IEnumerator UseBattery()
        {
            while (isOn)
            {
                yield return new WaitForSeconds(5);
                charge--;
                batteryText.text = charge.ToString() + "/" + maxcharge.ToString();
                if (charge <= 0) Switch();
            }
        }
    }
}