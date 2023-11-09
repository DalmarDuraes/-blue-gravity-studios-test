using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BlueGravityStudios
{
    [CreateAssetMenu(fileName = "New Shop Cloth", menuName = "Shop Item/Cloth")]
    public class ClothScriptable : ItemScriptable
    {
        protected ClothScriptable(ItemType itemType)
        {
            ItemType = ItemType.Cloth;
        }
        public ClothType ClothType;

    }
}

