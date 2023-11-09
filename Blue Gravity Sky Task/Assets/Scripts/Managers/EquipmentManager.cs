using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class EquipmentManager : MonoBehaviour
    {
        [SerializeField] private EquipmentStruct _equipments;
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

        private void ChangeEquipment(InventoryItem inventoryItem)
        {
            if (inventoryItem.ItemScriptable is ClothScriptable)
                ChangeCloth(inventoryItem);
            // if (inventoryItemOnUiBase.ItemScriptable is WeaponScriptable)
            //     ChangeWeapon(inventoryItemOnUiBase);
            
       
        }

        private void ChangeCloth(InventoryItem inventoryItemOnUiBase)
        {
            var clothScriptable = (ClothScriptable)inventoryItemOnUiBase.ItemScriptable;
            
            switch (clothScriptable.ClothType)
            {
                //case ClothType.Hood:
                //    _currentHood = inventoryItem.ItemSprite;
                //    _hood.sprite = _currentHood;
                //    
                //    break;
                //case ClothType.Shoulder:
                //    _currentShoulderL = inventoryItem.ItemSprite;
                //    _currentShoulderR = inventoryItem.SecondaryItemSprite;
                //    _shoulderL.sprite = _currentShoulderL;
                //    _shoulderR.sprite = _currentShoulderR;
                //    
                //    break;
                //default:
                //    Debug.LogError($"Did not found item type: {inventoryItem.ItemType}");
                //        break;
            }
        }
    }
}
