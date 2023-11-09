using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BlueGravityStudios
{
    [CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item/Item")]
    public class ShopItemScriptable : ScriptableObject
    {
        public Sprite ItemSprite;
        public Sprite SecondaryItemSprite;
        public String ItemName;
        public int ItemPrice;
        public ItemType ItemType;

    }
}

