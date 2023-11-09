using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BlueGravityStudios
{
    public class InventoryItem : MonoBehaviour
    {
        private ItemType _itemType;

        private void SetItemType(ItemType itemType)
        {
            _itemType = itemType;
        }
    }
}