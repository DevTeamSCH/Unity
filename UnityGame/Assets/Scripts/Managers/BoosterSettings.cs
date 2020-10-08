using System.Collections.Generic;
using Boosters;
using UnityEngine;

namespace Managers{
    public class BoosterSettings{
        internal List<Booster> appliedBoosters = new List<Booster>();
        internal List<Booster> delete = new List<Booster>();
        private readonly HealthController _hpcontrolController;
        private readonly JeremyController _jeremyController;

        public BoosterSettings(GameManager gameManager){
            _hpcontrolController = gameManager.player.GetComponent<HealthController>();
            _jeremyController = gameManager.player.GetComponent<JeremyController>();
        }
		
        public void Boost(float duration, float value, string type){
            appliedBoosters.Add(new Booster(duration, value, type));
            switch (type){
                case "Hp":
                    _hpcontrolController.ApplyHpBooster((int) value);
                    break;
                case "Jmp":
                    _jeremyController.AppyJmpBooster(value);
                    break;
            }
        }

        internal void DeBoost(Booster boost){
            switch (boost.type){
                case "Hp":
                    _hpcontrolController.DenyHpBooster((int) boost.value);
                    break;
                case "Jmp":
                    _jeremyController.DenyJmpBooster(boost.value);
                    break;
            }

            appliedBoosters.Remove(boost);
        }
    }
}
