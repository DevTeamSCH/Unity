using UnityEngine;

namespace Managers.Inventory {
    public abstract class InventoryController : MonoBehaviour
    {
        public Inventory inventory;
        public GameObject ui;
    
        protected virtual void Start() {
            inventory = new Inventory(ui);
        }

        public virtual void SwitchState() {
            inventory.SwitchState();
        }

        public abstract void FixedUpdate();
    }
}
