using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BlueGravityStudios
{
    public abstract class ItemScriptable : ScriptableObject
    {
        public Sprite ItemSprite;
        public Sprite SecondaryItemSprite;
        public Sprite SpriteForPanels;
        public String ItemName;
        public int ItemPrice;
        public ItemType ItemType { get; protected set; }
    }
}

