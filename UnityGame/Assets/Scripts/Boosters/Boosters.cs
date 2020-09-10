using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Object{
	private float _duration;
	private float _tmpTime = 0f;
	public float value;
	public string type;

	public Booster(float duration, float value, string type){
		_duration = duration;
		_tmpTime = 0;
		this.value = value;
	}

	public bool Refresh(){
		_tmpTime += Time.deltaTime;
		return _tmpTime >= _duration;
	}

	public string Write(){
		int sec = (int) (_duration - _tmpTime) + 1;
		string ret = (sec / 60).ToString("00") + ":" + (sec % 60).ToString("00");
		return ret;
	}
}