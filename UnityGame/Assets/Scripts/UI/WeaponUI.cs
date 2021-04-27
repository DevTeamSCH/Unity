using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RL.UI
{
    public class WeaponUI : MonoBehaviour
    {
        public Image[] weaponPanels;
        public TextMeshProUGUI ammoText;
        int activeidx = 0;
        // Start is called before the first frame update
        public void ChooseWeapon(int idx)
        {
            Color tmp = weaponPanels[activeidx].color;
            tmp.a = 0.5f;
            weaponPanels[activeidx].color = tmp;

            tmp = weaponPanels[idx].color;
            tmp.a = 1f;
            weaponPanels[idx].color = tmp;

            activeidx = idx;
        }

        public void UpdateAmmo(int current, int max)
        {
            ammoText.SetText(current + "/" + max);
        }
    }
}