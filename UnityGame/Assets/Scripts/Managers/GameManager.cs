using System;
using System.Collections.Generic;
using Boosters;
using UnityEngine;
using UnityEngine.UI;

namespace Managers{
	public class GameManager : MonoBehaviour{
		public static GameManager gameManager;
		public GameObject player;
		
		public static BoosterSettings boosterSettings;
		public Text boosterText;
		
		public static InventorySystem inventorySystem;
		public Text targetName;
		
		private void Awake(){
			gameManager = this;
			boosterSettings = new BoosterSettings(gameManager);
			inventorySystem = new InventorySystem(gameManager);
		}

		private void FixedUpdate(){
			//Booster refresh
			string tmpBoostText = "";

			foreach (var delete in boosterSettings.delete){
				boosterSettings.DeBoost(delete);
			}
		
			boosterSettings.delete = new List<Booster>();

			foreach (var booster in boosterSettings.appliedBoosters){
				if(booster.Refresh())
					boosterSettings.delete.Add(booster);
				tmpBoostText += booster.Write();
			}

			boosterText.text = tmpBoostText;
		}

		private void Update(){
			targetName.text = inventorySystem.NameView();
		}
	}
}