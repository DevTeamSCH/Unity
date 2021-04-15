using System;
using System.Dynamic;
using UnityEngine;

namespace Scriptable_Objects {
	[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/newItem", order = 1)]
	public class Item : ScriptableObject {
		public Sprite img;
		public float pickUpDistane = 5.0f;
		public String itemName;

		public void Clone(Item other) {
			img = other.img;
			pickUpDistane = other.pickUpDistane;
			itemName = other.itemName;
		}

		public int SlotId { get; set; }

		public virtual string getStack() {
			return "";
		}

		public virtual bool isStackable() {
			return false;
		}
	}
}
