using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/newItem", order = 1)]
public class Item : ScriptableObject {
	private int _slot;
	public Sprite img;
	public float pickUpDistane = 5.0f;
	public String itemName;


	public void SetSlot(int slot){
		_slot = slot;
	}
		
	public int GetSlot(){
		return _slot;
	}

	public static int Compare(Item i1, Item i2){
		return i1._slot.CompareTo(i2._slot);
	}
}
