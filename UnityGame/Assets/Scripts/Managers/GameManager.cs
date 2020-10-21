using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers{
	public class GameManager : MonoBehaviour{
		public static GameManager gameManager;
		public GameObject player;
		
		public BoosterSettings boosterSettings;
		public Text boosterText;
		
		public ViewSystem viewSystem;
		public Text targetName;
		
		[Header("Inventory Variables")]
		public Sprite originalSlot;
		public InventoryEvents iE;
		public GameObject tmpItem;
		
		private void Awake(){
			gameManager = this;
			boosterSettings = new BoosterSettings(gameManager);
			viewSystem = new ViewSystem(gameManager);
			iE = new InventoryEvents(tmpItem);
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
			viewSystem.UpdateRay();
			targetName.text = viewSystem.NameView();
			iE.Update();
		}
	}
}