using UnityEngine;

namespace Scriptable_Objects {
	[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/newStackableItem", order = 2)]
	public class StackableItem : Item {
		public int _num = 1;

		public override string getStack() {
			return _num.ToString();
		}

		public override bool isStackable() {
			return true;
		}
	}	
}