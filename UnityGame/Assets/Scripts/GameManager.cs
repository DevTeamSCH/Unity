using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
	public static GameManager gameManager;
	public GameObject player;
	public Text boosterText;
	

	//boosters
	public abstract class BoosterSettings{
		internal static List<Booster> appliedBoosters = new List<Booster>();
		internal static List<Booster> delete = new List<Booster>();
		private static HealthController _hpcontrolController = gameManager.player.GetComponent<HealthController>();
		private static JeremyController _jeremyController = gameManager.player.GetComponent<JeremyController>();
		
		public static void Boost(float duration, float value, string type){
			appliedBoosters.Add(new Booster(duration, value, type));
			switch (type){
				case "Hp":
					_hpcontrolController.ApplyHpBooster((int) value);
					break;
				case "Jmp":
					_jeremyController.AppyJmpBooster(value);
					break;
			}
		}

		internal static void DeBoost(Booster boost){
			switch (boost.type){
				case "Hp":
					_hpcontrolController.DenyHpBooster((int) boost.value);
					break;
				case "Jmp":
					_jeremyController.DenyJmpBooster(boost.value);
					break;
			}

			appliedBoosters.Remove(boost);
		}
	}

	private void Awake(){
		gameManager = this;
	}

	private void FixedUpdate(){
		//Booster refresh TODO:Debug, if the last element of the list expires the booster text disappear
		string tmpBoostText = "";

		foreach (var delete in BoosterSettings.delete){
			BoosterSettings.DeBoost(delete);
		}
		
		BoosterSettings.delete = new List<Booster>();

		foreach (var booster in BoosterSettings.appliedBoosters){
			if(booster.Refresh())
				BoosterSettings.delete.Add(booster);
			tmpBoostText += booster.Write();
		}

		boosterText.text = tmpBoostText;
	}
}