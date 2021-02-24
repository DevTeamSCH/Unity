using System.Collections.Generic;
using Managers.Inventory;
using UnityEngine;

namespace Scriptable_Objects {
	[CreateAssetMenu(fileName = "inventory", menuName = "ScriptableObjects/newInventory", order = 3)]
	public class Inventory : ScriptableObject {
		private List<Item> _items;
		private ItemSlot[] _itemSlots;
	
		public int maxSize;
		public Canvas uiPrefab;
		public Canvas ui;

		public void Init() {
			_items = new List<Item>();
			ui = Instantiate(uiPrefab);

			_itemSlots = ui.GetComponentsInChildren<ItemSlot>();
			ui.gameObject.SetActive(false);
		
			RefreshInventory();
		}
	
		public bool IsFull(){
			return _items.Count == maxSize;
		}

		public ref List<Item> GetItemList() {
			return ref _items;
		}

		public void SwitchState() {
			RefreshInventory();
			ui.gameObject.SetActive(!ui.gameObject.activeSelf);
		}

		public int LowestEmptyIndex {
			get {
				if (!IsFull()){
					for (int i = 0; i < _itemSlots.Length; ++i)
						if (_itemSlots[i].IsEmpty())
							return i;
				}
				return -1;
			}
		}

		public void RefreshInventory(){
			List<Item> tmpList = new List<Item>();
			foreach (var slot in _itemSlots){
				if (slot.Item != null)
					tmpList.Add(slot.Item);
			}

			_items = tmpList;
		}

		public void Store(ref Item item) {
			if (!IsFull()){
				item.Slot = LowestEmptyIndex;
				_items.Add(item);
				_itemSlots[item.Slot].Item = item;
			}
		}
	
	
	}
}
