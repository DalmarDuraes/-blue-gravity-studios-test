using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityStudios
{
    public class ShopItem: Item
    {
        public void BuyItem()
        {
            EventManager.Trigger<Item>(EconomyEvents.TryBuyItem, this);
        }
    }

}