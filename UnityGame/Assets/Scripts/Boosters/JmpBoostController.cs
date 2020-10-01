﻿using Managers;
using UnityEngine;

namespace Boosters{
	public class JmpBoostController : MonoBehaviour{
		public float duration = 5.0f;
		public float value = 5f;
	
		private void OnTriggerEnter(Collider other){
			if (other.CompareTag("Player")){
				GameManager.boosterSettings.Boost(duration, value, "Jmp");
				Destroy(this.gameObject);
			}
		}
	}
}