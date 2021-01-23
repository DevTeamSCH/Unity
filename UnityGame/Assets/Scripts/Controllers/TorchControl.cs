using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
    bool isOn = false;
    int charge;
    int maxcharge = 100;
    public GameObject lightSource;
    // Start is called before the first frame update
    void Start()
    {
        charge = maxcharge;
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.F))
        {
            Switch();
        }
    }

    public void Switch()
    {
        if(charge>0)
        {
            isOn = !isOn;
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
        while(isOn)
        {
            yield return new WaitForSeconds(5);
            charge--;
            if (charge <= 0) Switch();
        }
    }
}
