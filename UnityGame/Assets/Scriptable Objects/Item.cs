using System;
using UnityEngine;

namespace Scriptable_Objects {
	[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/newItem", order = 1)]
	public class Item : ScriptableObject {
		public Sprite img;
		public float pickUpDistane = 5.0f;
		public String itemName;

		public int Slot { get; set; }

		public static int Compare(Item i1, Item i2){
			return i1.Slot.CompareTo(i2.Slot);
		}
	}
}
