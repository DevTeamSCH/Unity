using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RL.Player
{
    public class SanityController : MonoBehaviour
    {
        public int sanity = 100;
        public int maxSanity = 100;
        public TextMeshProUGUI sanityPanel;
        private bool torchOn = true;
        public float SanityPercentage
        {
            get
            {
                return ((float)sanity) / maxSanity;
            }
        }
        public bool TorchOn
        {
            get
            {
                return torchOn;
            }
            set
            {
                if (value)
                {
                    StartCoroutine(GainSanity());

                }
                else
                {
                    StartCoroutine(DrainSanity());
                }

                torchOn = value;
            }
        }
        public int sanityDrainTime = 10; //seconds by which sanity is drained
        public int sanityGainRate = 11; //same for gain
        IEnumerator DrainSanity()
        {

            while (!torchOn)
            {
                sanity--;
                UpdatePanel();
                yield return new WaitForSeconds(sanityDrainTime);
                //TODO do something when it's done
            }
        }

        IEnumerator GainSanity()
        {
            while (torchOn)
            {
                if (sanity < maxSanity)
                {
                    sanity++;
                    UpdatePanel();
                }

                yield return new WaitForSeconds(sanityGainRate);
            }
        }

        void UpdatePanel()
        {
            sanityPanel.text = sanity.ToString() + "/" + maxSanity.ToString();
        }
        void Start()
        {
            sanity = maxSanity;

        }

    }
}