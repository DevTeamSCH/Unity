using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class tmpItemController : MonoBehaviour{
    private Image _img;

    private void Start(){
        _img = GetComponent<Image>();
        ResetSprite();
    }

    public void SetSprite(Sprite sprite){
        _img.sprite = sprite;
        _img.color = Color.white;
    }

    public void ResetSprite(){
        _img.sprite = null;
        _img.color = new Color(0,0,0,0);
    }

    public bool IsEmpty(){
        return _img.sprite is null;
    }
}
