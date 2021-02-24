using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;

namespace Managers.Inventory {
	public class Inventory {
		private List<Item> _items;
		private readonly ItemSlot[] _itemSlots;
		private bool _open;
	
		private readonly int _maxSize;
		private GameObject _ui;

		public Inventory(GameObject ui) {
			_items = new List<Item>();
			_open = false;

			_itemSlots = ui.GetComponentsInChildren<ItemSlot>();
			int i = 0;
			foreach (ItemSlot slot in _itemSlots) {
				slot.SlotId = i++;
			}
			
			ui.gameObject.SetActive(false);
			_ui = ui;
			_maxSize = _itemSlots.Length;
		}
	
		public bool IsFull(){
			return _items.Count == _maxSize;
		}

		public void SwitchState() {
			if (_open) {
				ClearUi();
			} else {
				FillUi();
			}

			_open = !_open;
			_ui.SetActive(!_ui.activeSelf);
		}

		private int LowestEmptyIndex {
			get {
				if (!IsFull()){
					int ret = 0;
					bool empty;
					do {
						empty = true;
						foreach (var item in _items) {
							if (ret == item.SlotId) {
								empty = false;
								++ret;
							}
						}
					} while (!empty);

					return ret;
				}
				return -1;
			}
		}

		public void ClearUi() {
			List<Item> tmpItems = new List<Item>();

			foreach (var slot in _itemSlots){
				if (!(slot.Item is null)) {
					tmpItems.Add(slot.Item);
					slot.RemoveContent();
				}
			}

			_items = tmpItems;
		}

		public void FillUi() {
			foreach (var item in _items) {
				_itemSlots[item.SlotId].Item = item;
			}
		}

		public void Store(ref Item item) {
			if (!IsFull()){
				item.SlotId = LowestEmptyIndex;
				_items.Add(item);
			}
		}
	}
}
