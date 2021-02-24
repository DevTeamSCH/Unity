using UnityEngine;

namespace Managers.Inventory {
    public abstract class InventoryController : MonoBehaviour
    {
        public Scriptable_Objects.Inventory inventory;
    
        protected virtual void Start() {
            inventory.Init();
        }

        public virtual void SwitchState() {
            inventory.SwitchState();
        }

        public abstract void FixedUpdate();
    }
}
