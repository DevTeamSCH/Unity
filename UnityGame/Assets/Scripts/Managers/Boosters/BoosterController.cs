using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class BoosterController : MonoBehaviour{
	public Booster booster;
	
	private void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			GameManager._instance.boosterSettings.Boost(booster);
			Destroy(gameObject);
		}
	}
}
