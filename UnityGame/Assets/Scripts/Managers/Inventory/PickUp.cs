using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;


public class PickUp : MonoBehaviour
{
    private Item _item;

    public float pickUpDistane = 5.0f;
    public String itemName;
    public Sprite itemImage;

    private void Awake(){
        _item = new Item(itemName, itemImage);
    }

    public bool PickItUp(float distance, ref Item pick){
        if (distance <= pickUpDistane){
            pick = _item;
            Destroy(this.gameObject);
            return true;
        }
        
        return false;
    }
}
