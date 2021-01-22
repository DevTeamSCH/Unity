using System.Collections.Generic;
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
		
        public void Boost(Booster boost){
            appliedBoosters.Add(boost);
            switch (boost.type){
                case "Hp":
                    _hpcontrolController.ApplyHpBooster((int) boost.value);
                    break;
                case "Jmp":
                    _jeremyController.AppyJmpBooster(boost.value);
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
