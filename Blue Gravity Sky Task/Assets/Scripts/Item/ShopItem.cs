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
     
      
        protected override void Init()
        {
            base.Init();
            _shopImage.sprite = _itemSprite;
        }

        public void BuyItem()
        {
            EventManager.Trigger<Item>(EconomyEvents.TryBuyItem, this);
        }
    }

}