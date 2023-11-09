using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityStudios
{
    public class ShopItem: ItemOnUiBase
    {
        public void BuyItem()
        {
            EventManager.Trigger<ItemOnUiBase>(EconomyEvents.TryBuyItem, this);
        }
    }

}