using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Managers;
using UnityEngine;

public class PlayerInventoryController : InventoryController {
    public Canvas viewSystem;

    public CameraControl cameraControl;
    private JeremyController _jeremy;
    private LookControl _look;
    private CursorLockMode _next;

    private bool _containerOpen;
    private ContainerInventoryController _tmpContainer;

    protected override void Start() {
        _containerOpen = false;
        viewSystem.gameObject.SetActive(true);
        _jeremy = GetComponent<JeremyController>();
        _look = GetComponentInChildren<LookControl>();
        
        _next = CursorLockMode.None;
        Cursor.visible = false;
        
        inventory.Init();
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
            if (GameManager.gameManager.viewSystem.GetSuccess()){
                RaycastHit hit = GameManager.gameManager.viewSystem.GetHit();
                if (!hit.Equals(null) && hit.collider.tag.Equals("Pickable")){
                    if (!inventory.IsFull()){
                        Debug.Log(hit.collider.tag);
                        Item tmpItem = null;
                        if (GameManager.gameManager.viewSystem.GetPickUp()
                            .PickItUp(GameManager.gameManager.viewSystem.GetDistanece(), ref tmpItem))
                            inventory.Store(ref tmpItem);
                    }
                } else if (!hit.Equals(null) && hit.collider.tag.Equals("Container")){
                    if (GameManager.gameManager.viewSystem.GetDistanece() <=
                        GameManager.gameManager.viewSystem.GetContainer().openDistance) {
                        GameManager.gameManager.viewSystem.GetContainer().SwitchState();
                        SwitchState();
                        _tmpContainer = GameManager.gameManager.viewSystem.GetContainer();
                        _containerOpen = true;
                    }
                } else if (_containerOpen){
                    SwitchState();
                    _containerOpen = false;
                    _tmpContainer.SwitchState();
                }
            }
        } else if (Input.GetKeyDown("i")){
            if (_containerOpen){
                _containerOpen = false;
                _tmpContainer.SwitchState();
            }
            SwitchState();
        }
    }
}
