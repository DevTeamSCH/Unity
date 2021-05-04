using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
using Managers.Inventory;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Managers{
	public class ViewSystem {
		private GameManager _gameManager = GameManager._instance;
		private Ray _ray;
		private RaycastHit _hit;
		private bool _raySuccess = false;
		private float _hitDistance;
		private PickUpController _pickUp;
		private ContainerInventoryController _container;

		/*public ViewSystem(GameManager gameManager){
			_gameManager = gameManager;
		}*/

		public RaycastHit GetHit(){
			return _hit;
		}


		public bool GetSuccess(){
			return _raySuccess;
		}

		public float GetDistanece(){
			return _hitDistance;
		}

		public PickUpController GetPickUp(){
			return _pickUp;
		}
		
		public ContainerInventoryController GetContainer(){
			return _container;
		}

		public void UpdateRay(){
			_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			_raySuccess = Physics.Raycast(_ray, out _hit);
			if (_raySuccess && _gameManager.player!=null){
				_hitDistance = Vector3.Distance(_hit.collider.transform.position,
					_gameManager.player.transform.position);
				if (_hit.collider.tag.Equals("Pickable"))
					_pickUp = _hit.collider.GetComponent<PickUpController>();
				else if (_hit.collider.tag.Equals("Container"))
					_container = _hit.collider.GetComponent<ContainerInventoryController>();
				
			}
		}

		public String NameView(){
			if (_raySuccess){
				if (_hit.collider.tag.Equals("Booster")){
					if (_hitDistance <= 10f)
						return _hit.collider.name;
				} else if (_hit.collider.tag.Equals("Pickable")){
					if (_hitDistance <= _pickUp.item.pickUpDistane)
						return _pickUp.item.itemName + " (E)";
					if (_hitDistance <= 10f)
						return _pickUp.item.itemName;
				} else if (_hit.collider.tag.Equals("Container")) {
					if (_hitDistance <= _container.openDistance)
						return _container.name + " (E)";
					if (_hitDistance <= 10f)
						return _container.name;
				}
			}

			return String.Empty;
		}
	}
}
