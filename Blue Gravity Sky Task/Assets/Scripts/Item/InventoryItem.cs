using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlueGravityStudios
{
    public class InventoryItem : Item
    {
        [SerializeField] private Image _inventoryImage;
        
        protected override void Init()
        {
            base.Init();
            _inventoryImage.sprite = _itemSprite;
        }

        public void SellItem()
        {
            EventManager.Trigger<Item>(EconomyEvents.SellItem, this);
        }

    }
}