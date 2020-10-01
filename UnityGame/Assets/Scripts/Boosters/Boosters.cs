using UnityEngine;

namespace Boosters{
	public class Booster : Object{
		private readonly float _duration;
		private float _tmpTime = 0f;
		public readonly float value;
		public readonly string type;

		public Booster(float duration, float value, string type){
			_duration = duration;
			_tmpTime = 0;
			this.value = value;
			this.type = type;
		}

		public bool Refresh(){
			_tmpTime += Time.deltaTime;
			return _tmpTime >= _duration;
		}

		public string Write(){
			int sec = (int) (_duration - _tmpTime) + 1;
			string ret = type + ":" + (sec / 60).ToString("00") + ":" + (sec % 60).ToString("00") + '\n';
			return ret;
		}
	}
}