using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour{
	private bool _empty = true;
    private Image _image;
    

    private void Awake(){
        _image = this.GetComponent<Image>();
    }

    public void SetSprite(Sprite sprite){
       _image.sprite = sprite;
       _empty = false;
    }

    public void RemoveContent(){
	    _empty = true;
	    
    }

    public bool IsEmpty(){
	    return _empty;
    }
    
}
