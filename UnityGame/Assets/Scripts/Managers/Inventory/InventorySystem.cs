using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Object = UnityEngine.Object;

namespace Managers{
	public class ViewSystem{
		private GameManager _gameManager;
		private Ray _ray;
		private RaycastHit _hit;
		private bool _raySuccess = false;
		private float _hitDistance;
		private PickUp _pickUp;

		public ViewSystem(GameManager gameManager){
			_gameManager = gameManager;
		}

		public RaycastHit GetHit(){
			return _hit;
		}

		public bool GetSuccess(){
			return _raySuccess;
		}

		public float GetDistanece(){
			return _hitDistance;
		}

		public PickUp GetPickUp(){
			return _pickUp;
		}

		public void UpdateRay(){
			_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			_raySuccess = Physics.Raycast(_ray, out _hit);
			if (_raySuccess){
				_hitDistance = Vector3.Distance(_hit.collider.transform.position,
					_gameManager.player.transform.position);
				if (_hit.collider.tag.Equals("Pickable"))
					_pickUp = _hit.collider.GetComponent<PickUp>();
			}
		}

		public String NameView(){
			if (_raySuccess){
				if (_hit.collider.tag.Equals("Booster")){
					if (_hitDistance <= 10f)
						return _hit.collider.name;
				} else if (_hit.collider.tag.Equals("Pickable")){
					if (_hitDistance <= _pickUp.pickUpDistane)
						return _pickUp.itemName + " (E)";
					if (_hitDistance <= 10f)
						return _pickUp.itemName;
				}
			}

			return String.Empty;
		}
	}

	public class Item {
		private String _name;
		private int _slot;
		private Sprite _img;

		public Sprite GetSprite(){
			return _img;
		}

		public String GetName(){
			return _name;
		}

		public Item(String name, Sprite img){
			_name = name;
			_img = img;
		}

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

	public class Inventory{
		public List<Item> _items;
		private readonly int _maxSize;
		private ItemSlot[] _itemSlots;

		public Inventory(int size, Canvas canv){
			_items = new List<Item>();
			_maxSize = size;
			_itemSlots = canv.GetComponentsInChildren<ItemSlot>();
		}
		
		private int GetLowestIndex(){
			if (!IsFull()){
				for (int i = 0; i < _itemSlots.Length; ++i)
					if (_itemSlots[i].IsEmpty())
						return i;
			}
			return -1;
		}

		public bool IsFull(){
			return _items.Count == _maxSize;
		}

		public void Store(ref Item item){
			if (!IsFull()){
				item.SetSlot(GetLowestIndex());
				_items.Add(item);
				_items.Sort(Item.Compare);
				foreach (var tmpItem in _items){
					_itemSlots[tmpItem.GetSlot()].SetSprite(tmpItem.GetSprite());
				}
			}
		}
	}
}
