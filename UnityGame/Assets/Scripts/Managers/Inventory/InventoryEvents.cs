using Scriptable_Objects;
using UnityEngine;

namespace Managers.Inventory {
    public class InventoryEvents{
        private Item _tmpClicked;
        private ItemSlot _tmpSlot;
    
        private Transform _tmpGameObjectTrans;
        private tmpItemController _tmpGameObjectController;
    
        private bool _isTmpClickedNotNull;

        public InventoryEvents(GameObject gameObject){
            _tmpClicked = null;
            _tmpGameObjectTrans = gameObject.GetComponent<Transform>();
            _tmpGameObjectController = gameObject.GetComponent<tmpItemController>();
        }

        public Item TmpClicked {
            get => _tmpClicked;
            set {
                _tmpClicked = value;
                _tmpGameObjectController.SetSprite(value.img);
            }
        }

        public ItemSlot TmpSlot {
            set => _tmpSlot = value;
        }


        public void Reset(){
            _tmpClicked = null;
            _tmpGameObjectController.ResetSprite();
        }

        public void Swap(ItemSlot slot) {
            _tmpSlot.Item = slot.Item;
            slot.Item = _tmpClicked;
            Reset();
        }

        public void Update(){
            if (!_tmpGameObjectController.IsEmpty()){
                _tmpGameObjectTrans.position = Input.mousePosition;
            }
        }
    }
}
