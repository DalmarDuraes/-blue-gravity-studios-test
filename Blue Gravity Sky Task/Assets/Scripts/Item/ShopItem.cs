using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityStudios
{
    public class ShopItem : Item
    {
        [SerializeField] private Image _shopImage;
        [SerializeField] private TextMeshProUGUI _itemPriceTxt;
      
        protected override void Init()
        {
            base.Init();
            _itemPriceTxt.text = _itemPrice.ToString();
            _shopImage.sprite = _itemSprite;
        }
    }

}