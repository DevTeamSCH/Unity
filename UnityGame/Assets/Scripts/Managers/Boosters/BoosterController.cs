using System.Collections;
using System.Collections.Generic;
using RL.Managers;
using UnityEngine;
namespace RL.Managers
{
	public class BoosterController : MonoBehaviour
	{
		public Booster booster;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				GameManager._instance.boosterSettings.Boost(booster);
				Destroy(gameObject);
			}
		}
	}
}