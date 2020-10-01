using System;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Object = UnityEngine.Object;

namespace Managers{
	public class InventorySystem : Object{
		private GameManager _gameManager;

		public InventorySystem(GameManager gameManager){
			_gameManager = gameManager;
		}

		public String NameView(){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				if (hit.collider.tag.Equals("Booster") || hit.collider.tag.Equals("Pickable"))
					
					if ((Vector3.Distance(hit.collider.transform.position, _gameManager.player.transform.position)
					     <= 5f) && hit.collider.tag.Equals("Pickable")){
						return hit.collider.name + " (E)";
						
					} else if (Vector3.Distance(hit.collider.transform.position, _gameManager.player.transform.position)
					           <= 10f){
						return hit.collider.name;
					}
			}
			
			return String.Empty;
		}
	}
}
