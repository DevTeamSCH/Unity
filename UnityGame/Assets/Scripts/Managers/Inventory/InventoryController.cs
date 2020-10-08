using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
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
    

    private void Awake(){
        _inventory = new Inventory(inventorySize, inventoryCanvas);
        _inventoryOpen = false;
        viewSystem.gameObject.SetActive(true);
        inventoryCanvas.gameObject.SetActive(false);
        _itemSlots = inventoryCanvas.GetComponentsInChildren<ItemSlot>();
        Debug.Log(_itemSlots.Length);
    }

    public void OpenInventory(){
        _inventoryOpen = true;
        viewSystem.gameObject.SetActive(false);
        inventoryCanvas.gameObject.SetActive(true);
    }
    
    public void CloseInventory(){
        _inventoryOpen = false;
        viewSystem.gameObject.SetActive(true);
        inventoryCanvas.gameObject.SetActive(false);
    }

    private void FixedUpdate(){
        if (this.tag.Equals("Player")){
            if (Input.GetKey("e") && !_pushede){
                _pushede = true;
                if (GameManager.viewSystem.GetSuccess()){
                    RaycastHit hit = GameManager.viewSystem.GetHit();
                    if (!hit.Equals(null) && hit.collider.tag.Equals("Pickable")){
                        if (!_inventory.IsFull()){
                            Item tmpItem = null;
                            if (GameManager.viewSystem.GetPickUp()
                                .PickItUp(GameManager.viewSystem.GetDistanece(), ref tmpItem))
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
