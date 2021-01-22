using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int selectedWeapon = 0; //index of the selected weapon
    public WeaponUI ui;

    public int SelectedWeapon //auto-rotate incrementation and decrementation
    {
        get { return selectedWeapon; }
        set
        {
            if (value > transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else if (value < 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else selectedWeapon = value;

        }
    }
    void Start()
    {
        SelectWeapon();

    }



    // Update is called once per frame
    void Update()
    {
        int previousWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            SelectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SelectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            SelectedWeapon = 1;
        }

        if (previousWeapon != selectedWeapon) SelectWeapon();
    }
    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon) weapon.gameObject.SetActive(true);
            else weapon.gameObject.SetActive(false);
            i++;
        }
        ui.ChooseWeapon(SelectedWeapon);

    }
}
