using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "booster", menuName = "ScriptableObjects/newBooster", order = 2)]
public class Booster : ScriptableObject {
	public float duration;
	public float value;
	public string type;
	private float _tmpTime = 0f;

	public bool Refresh(){
		_tmpTime += Time.deltaTime;
		return _tmpTime >= duration;
	}

	public string Write(){
		int sec = (int) (duration - _tmpTime) + 1;
		string ret = type + ":" + (sec / 60).ToString("00") + ":" + (sec % 60).ToString("00") + '\n';
		return ret;
	}
}