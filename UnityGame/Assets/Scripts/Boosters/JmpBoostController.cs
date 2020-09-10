using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JmpBoostController : MonoBehaviour{
	public float duration = 5.0f;
	public float value = 5f;
	
	private void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			other.GetComponent<JeremyController>().BoostJmp(duration, value);
			Destroy(this.gameObject);
		}
	}
}