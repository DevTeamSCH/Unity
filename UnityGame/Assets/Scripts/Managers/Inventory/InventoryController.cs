using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Managers;
using UnityEngine;

public abstract class InventoryController : MonoBehaviour
{
    public Inventory inventory;
    
    protected virtual void Start() {
        inventory.Init();
    }

    public virtual void SwitchState() {
        inventory.SwitchState();
    }

    public abstract void FixedUpdate();
}
