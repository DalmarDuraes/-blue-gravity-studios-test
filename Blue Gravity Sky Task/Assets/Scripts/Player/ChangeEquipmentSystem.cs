using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class ChangeEquipmentSystem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _hood;
        [SerializeField] private SpriteRenderer _shoulderL;
        [SerializeField] private SpriteRenderer _shoulderR;

        [SerializeField] private Sprite _currentHood;
        [SerializeField] private Sprite _currentShoulderL;
        [SerializeField] private Sprite _currentShoulderR;

        private void Awake()
        {
            _currentHood = _hood.sprite;
            _currentShoulderL = _shoulderL.sprite;
            _currentShoulderR = _shoulderR.sprite;
        }

        private void ChangeEquipment(InventoryItem inventoryItemOnUiBase)
        {
           // switch (inventoryItem.ItemType)
           // {
           //     case ItemType.Hood:
           //         _currentHood = inventoryItem.ItemSprite;
           //         _hood.sprite = _currentHood;
           //         
           //         break;
           //     case ItemType.Shoulder:
           //         _currentShoulderL = inventoryItem.ItemSprite;
           //         _currentShoulderR = inventoryItem.SecondaryItemSprite;
           //         _shoulderL.sprite = _currentShoulderL;
           //         _shoulderR.sprite = _currentShoulderR;
           //         
           //         break;
           //     default:
           //         Debug.LogError($"Did not found item type: {inventoryItem.ItemType}");
           //             break;
           // }
        }
    }
}
