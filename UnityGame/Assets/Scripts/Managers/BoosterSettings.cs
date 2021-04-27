using RL.Player;
using System.Collections.Generic;
using UnityEngine;

namespace RL.Managers{
    public class BoosterSettings{
        internal List<Booster> appliedBoosters = new List<Booster>();
        internal List<Booster> delete = new List<Booster>();
        private readonly HealthController _hpcontrolController;
        private readonly JeremyController _jeremyController;
        private readonly TorchControl _torchController;

        public BoosterSettings(GameManager gameManager){
            _hpcontrolController = gameManager.player.GetComponent<HealthController>();
            _jeremyController = gameManager.player.GetComponent<JeremyController>();
            _torchController = _jeremyController.GetComponentInChildren<TorchControl>();
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
                case "Bttr":
                    _torchController.Recharge(); 
                    break;
                default: break;
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
                default: break;
            }

            appliedBoosters.Remove(boost);
        }
    }
}
