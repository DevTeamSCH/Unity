using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour{
    private Inventory _inventory;

    public int inventorySize = 5;
    public Canvas viewSystem;
    public Canvas inventoryCanvas;
    
    private bool _pushede = false;
    private bool _pushedi = false;
    private bool _inventoryOpen = false;
    private ItemSlot[] _itemSlots;

    public CameraControl cameraControl;
    private JeremyController _jeremy;
    private LookControl _look;

    private void Awake(){
        _inventory = new Inventory(inventorySize, inventoryCanvas);
        _inventoryOpen = false;
        viewSystem.gameObject.SetActive(true);
        inventoryCanvas.gameObject.SetActive(false);
        _itemSlots = inventoryCanvas.GetComponentsInChildren<ItemSlot>();
        if (tag.Equals("Player")){
            _jeremy = GetComponent<JeremyController>();
            _look = GetComponentInChildren<LookControl>();
        }
    }

    public void OpenInventory(){
        _inventoryOpen = true;
        viewSystem.gameObject.SetActive(false);
        inventoryCanvas.gameObject.SetActive(true);

        _jeremy.enabled = false;
        _look.enabled = false; 
        cameraControl.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void CloseInventory(){
        _inventoryOpen = false;
        viewSystem.gameObject.SetActive(true);
        inventoryCanvas.gameObject.SetActive(false);
        
        _jeremy.enabled = true;
        _look.enabled = true;
        cameraControl.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate(){
        if (this.tag.Equals("Player")){
            if (Input.GetKey("e") && !_pushede){
                _pushede = true;
                if (GameManager.gameManager.viewSystem.GetSuccess()){
                    RaycastHit hit = GameManager.gameManager.viewSystem.GetHit();
                    if (!hit.Equals(null) && hit.collider.tag.Equals("Pickable")){
                        if (!_inventory.IsFull()){
                            Item tmpItem = null;
                            if (GameManager.gameManager.viewSystem.GetPickUp()
                                .PickItUp(GameManager.gameManager.viewSystem.GetDistanece(), ref tmpItem))
                                _inventory.Store(ref tmpItem);
                        }
                    }
                }
            } else if (Input.GetKey("i") && !_pushedi){
                _pushedi = true;
                if (_inventoryOpen)
                    CloseInventory();
                else
                    OpenInventory();
            } else if (Input.GetKeyUp("e")){
                _pushede = false;
            } else if (Input.GetKeyUp("i")){
                _pushedi = false;
            }
        }
    }
}
