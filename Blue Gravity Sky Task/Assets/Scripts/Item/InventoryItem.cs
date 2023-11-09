using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlueGravityStudios
{
    public class InventoryItem: ItemOnUiBase
    {
        protected override void Init()
        {
            base.Init();
            _itemPriceTxt.text = _itemSellPrice.ToString();
        }

        public void SellItem()
        {
            EventManager.Trigger<ItemOnUiBase>(EconomyEvents.SellItem, this);
        }
        public void TryEquipItem()
        {
            EventManager.Trigger<ItemOnUiBase>(PlayerEvents.EquipItem, this);
        }

    }
}