using System;
using UnityEngine;

namespace Scriptable_Objects {
	[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/newItem", order = 1)]
	public class Item : ScriptableObject {
		public Sprite img;
		public float pickUpDistane = 5.0f;
		public String itemName;
		public bool stackable = false;
		public int SlotId { get; set; }
	}
}
