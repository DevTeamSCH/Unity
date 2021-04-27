using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

namespace RL.UI
{
    public class BackgroundControl : MonoBehaviour
    {
        private Text _text;
        private Image _image;
        private GameObject _imageObj;

        private void Start()
        {
            _text = this.GetComponentInChildren<Text>();
            _image = this.GetComponentInChildren<Image>();
            _imageObj = this.GetComponentInChildren<Image>().gameObject;
        }

        private void Update()
        {
            if (_text.text.Equals(""))
            {
                _imageObj.SetActive(false);

            }
            else
            {
                _imageObj.SetActive(true);

            }
        }
    }
}