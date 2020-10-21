using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemSlot : MonoBehaviour {
	private bool _empty = true;
	private Image _image;
	private Item _storedItem;
	private ItemSlot _thisSlot;

	private void Awake() {
		_image = GetComponent<Image>();
		_thisSlot = GetComponent<ItemSlot>();
	}

	public void SetItem(Item item) {
		_storedItem = item;
		_image.sprite = item.img;
		_empty = false;
	}

	public Item GetItem() {
		return _storedItem;
	}

	public void RemoveContent() {
		_image.sprite = GameManager.gameManager.originalSlot;
		_storedItem = null;
		_empty = true;
	}

	public void OnClick() {
		Item tmp = GameManager.gameManager.iE.GetTmpClicked();
		Debug.Log(tmp);
		if (_empty) {
			if (tmp != null) {
				SetItem(tmp);
				GameManager.gameManager.iE.Reset();
			}
		} else {
			if (tmp == null) {
				GameManager.gameManager.iE.SetTmpClicked(_storedItem);
				GameManager.gameManager.iE.SetTmpSlot(_thisSlot);
				RemoveContent();
			} else {
				GameManager.gameManager.iE.Swap(_thisSlot);
			}
		}
	}

	public bool IsEmpty() {
		return _empty;
	}
}