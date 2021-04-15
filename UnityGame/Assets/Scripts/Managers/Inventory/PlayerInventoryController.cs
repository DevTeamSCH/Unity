using Scriptable_Objects;
using UnityEngine;

namespace Managers.Inventory {
    public class PlayerInventoryController : InventoryController {
        public Canvas viewSystem;

        public CameraControl cameraControl;
        private JeremyController _jeremy;
        private LookControl _look;
        private CursorLockMode _next;

        private bool _containerOpen;
        private ContainerInventoryController _tmpContainer;

        protected override void Start() {
            base.Start();
            _containerOpen = false;
            viewSystem.gameObject.SetActive(true);
            _jeremy = GetComponent<JeremyController>();
            _look = GetComponentInChildren<LookControl>();
            _next = CursorLockMode.None;
            Cursor.visible = false;
        }

        public override void SwitchState() {
            viewSystem.gameObject.SetActive(!viewSystem.gameObject.activeSelf);
        
            _jeremy.enabled = !_jeremy.enabled;
            _look.enabled = !_look.enabled;
            cameraControl.enabled = !cameraControl.enabled;
        
            Cursor.visible = !Cursor.visible;
            CursorLockMode tmp = Cursor.lockState;
            Cursor.lockState = _next;
            _next = tmp;
        
            inventory.SwitchState();
        }

        public override void FixedUpdate(){
            if (Input.GetKeyDown("e")){
                if (GameManager._instance.viewSystem.GetSuccess()){
                    RaycastHit hit = GameManager._instance.viewSystem.GetHit();
                    if (!hit.Equals(null) && hit.collider.tag.Equals("Pickable")){
                        if (!inventory.IsFull()){
                            Debug.Log(hit.collider.tag);
                            Item tmpItem = null;
                            if (GameManager._instance.viewSystem.GetPickUp()
                                .PickItUp(GameManager._instance.viewSystem.GetDistanece(), ref tmpItem))
                                inventory.Store(tmpItem);
                        }
                    } else if (!hit.Equals(null) && hit.collider.tag.Equals("Container") && !_containerOpen){
                        if (GameManager._instance.viewSystem.GetDistanece() <=
                            GameManager._instance.viewSystem.GetContainer().openDistance) {
                            GameManager._instance.viewSystem.GetContainer().SwitchState();
                            SwitchState();
                            _tmpContainer = GameManager._instance.viewSystem.GetContainer();
                            _containerOpen = true;
                        }
                    } else if (_containerOpen){
                        SwitchState();
                        _containerOpen = false;
                        _tmpContainer.SwitchState();
                        _tmpContainer = null;
                    }
                }
            } else if (Input.GetKeyDown("i")){
                if (_containerOpen){
                    _containerOpen = false;
                    _tmpContainer.SwitchState();
                    _tmpContainer = null;
                }
                SwitchState();
            }
        }
    }
}
