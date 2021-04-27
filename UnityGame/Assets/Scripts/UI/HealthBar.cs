using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RL.UI
{
    public class HealthBar : MonoBehaviour
    {
        // Start is called before the first frame update

        Slider slider;
        void Start()
        {
            slider = GetComponent<Slider>();
        }
        public void SetPercent(float amount)
        {
            slider.SetValueWithoutNotify(amount);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}