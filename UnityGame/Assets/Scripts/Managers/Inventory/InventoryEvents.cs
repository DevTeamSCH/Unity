using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    
    public void SetTmpClicked(Item item){
        _tmpClicked = item;
        _tmpGameObjectController.SetSprite(item.img);
    }

    public void SetTmpSlot(ItemSlot slot) {
        _tmpSlot = slot;
    }

    public void Reset(){
        _tmpClicked = null;
        _tmpGameObjectController.ResetSprite();
    }

    public void Swap(ItemSlot slot) {
        _tmpSlot.SetItem(slot.GetItem());
        slot.SetItem(_tmpClicked);
        Reset();
    }

    public Item GetTmpClicked(){
        return _tmpClicked;
    }

    public void Update(){
        if (!_tmpGameObjectController.IsEmpty()){
            _tmpGameObjectTrans.position = Input.mousePosition;
        }
    }
}
