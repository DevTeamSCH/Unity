using Scriptable_Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.Inventory {
	[RequireComponent(typeof(Button))]
	public class ItemSlot : MonoBehaviour {
		private bool _empty = true;
		private Image _image;
		private Item _storedItem;
		private ItemSlot _thisSlot;
		private int _slotId;

		private void Awake() {
			_storedItem = null;
			_image = GetComponent<Image>();
			_thisSlot = GetComponent<ItemSlot>();
		}

		public void SetId(int id) {
			_slotId = id;
		}

		public Item Item {
			get => _storedItem;
			set {
				_storedItem = value;
				value.Slot = _slotId;
				_image.sprite = value.img;
				_empty = false;
			}
		}
		
		public void RemoveContent() {
			_image.sprite = GameManager._instance.originalSlot;
			_storedItem = null;
			_empty = true;
		}

		public void OnClick() {
			Item tmp = GameManager._instance.iE.TmpClicked;
			Debug.Log(this.transform.parent.name+" - " +tmp);
			if (_empty) {
				if (tmp != null) {
					Item = tmp;
					GameManager._instance.iE.Reset();
				}
			} else {
				if (tmp == null) {
					GameManager._instance.iE.TmpClicked = _storedItem;
					GameManager._instance.iE.TmpSlot = _thisSlot;
					RemoveContent();
				} else {
					GameManager._instance.iE.Swap(_thisSlot);
				}
			}
		}

		public bool IsEmpty() {
			return _empty;
		}
	}
}