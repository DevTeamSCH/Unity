using System;
using System.Collections;
using System.Collections.Generic;
using RL.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace RL.Managers
{
	[RequireComponent(typeof(Button))]

	public class ItemSlot : MonoBehaviour
	{
		private bool _empty = true;
		private Image _image;
		private Item _storedItem;
		private ItemSlot _thisSlot;
		private int _slotId;

		private void Awake()
		{
			_storedItem = null;
			_image = GetComponent<Image>();
			_thisSlot = GetComponent<ItemSlot>();
		}

		public void SetId(int id)
		{
			_slotId = id;
		}

		public void SetItem(Item item)
		{
			_storedItem = item;
			item.SetSlot(_slotId);
			_image.sprite = item.img;
			_empty = false;
		}

		public Item GetItem()
		{
			return _storedItem;
		}

		public void RemoveContent()
		{
			_image.sprite = GameManager._instance.originalSlot;
			_storedItem = null;
			_empty = true;
		}

		public void OnClick()
		{
			Item tmp = GameManager._instance.iE.GetTmpClicked();
			Debug.Log(this.transform.parent.name + " - " + tmp);
			if (_empty)
			{
				if (tmp != null)
				{
					SetItem(tmp);
					GameManager._instance.iE.Reset();
				}
			}
			else
			{
				if (tmp == null)
				{
					GameManager._instance.iE.SetTmpClicked(_storedItem);
					GameManager._instance.iE.SetTmpSlot(_thisSlot);
					RemoveContent();
				}
				else
				{
					GameManager._instance.iE.Swap(_thisSlot);
				}
			}
		}

		public bool IsEmpty()
		{
			return _empty;
		}
	}
}