using Managers;
using UnityEngine;

namespace Boosters{
	public class HpBoosterControl : MonoBehaviour{
		public float duration = 5.0f;
		public int value = 50;
	
		private void OnTriggerEnter(Collider other){
			if (other.CompareTag("Player")){
				GameManager.boosterSettings.Boost(duration, value, "Hp");
				Destroy(this.gameObject);
			}
		}
	}
}