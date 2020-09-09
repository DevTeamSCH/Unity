using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Object{
	protected float _duration;
	protected float _tmpTime = 0f;

	public Booster(float duration){
		_duration = duration;
		_tmpTime = 0;
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

public class HpBoost : Booster{
	public int value;
	public string type = "HP";

	public HpBoost(float duration, int value) : base(duration){
		this.value = value;
	}
}