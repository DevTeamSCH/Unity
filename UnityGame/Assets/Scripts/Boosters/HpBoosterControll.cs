using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HpBoosterControll : MonoBehaviour{
	public float duration = 5.0f;
	public int value = 50;
	
	private void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			GameManager.BoosterSettings.Boost(duration, value, "Hp");
			Destroy(this.gameObject);
		}
	}
}