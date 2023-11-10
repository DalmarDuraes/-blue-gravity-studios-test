using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;


namespace BlueGravityStudios
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryItem _inventoryItemPrefab;
        [SerializeField] private Transform _inventoryItemParent;
        [SerializeField] private InventoryUI _uiPanel;
        
        [SerializeField] private List<InventoryItem> _inventoryItemList = new List<InventoryItem>();
        public List<InventoryItem> InventoryItemList => _inventoryItemList;
        [SerializeField] protected Variable<ClothStruct> _currentClothEquipment;
        
        private bool _isOpen;
        private bool _isBlockedByOpenShop;
        
        private void OnEnable()
        {
            EventManager.Register<Item>(PlayerEvents.AddItemToInventory, AddItemToInventory);
            EventManager.Register<ItemScriptable>(PlayerEvents.AddItemToInventoryBySO, AddItemToInventoryBySO);
            EventManager.Register<InventoryItem>(PlayerEvents.RemoveItemFromInventory, RemoveItemFromInventory);
            EventManager.Register<bool>(NPCEvents.ToggleShop, OnAnyShopToggled); 
            EventManager.Register(PlayerEvents.PlayerInputToggleInventory, PlayerInputToggleInventory);
            EventManager.Register<bool>(PlayerEvents.UpdateInventoryItemsButtons, UpdateInventoryUItemsButton);
        }

        private void OnDisable()
        {
            EventManager.Unregister<Item>(PlayerEvents.AddItemToInventory, AddItemToInventory);
            EventManager.Unregister<ItemScriptable>(PlayerEvents.AddItemToInventoryBySO, AddItemToInventoryBySO);
            EventManager.Unregister<InventoryItem>(PlayerEvents.RemoveItemFromInventory, RemoveItemFromInventory);
            EventManager.Unregister<bool>(NPCEvents.ToggleShop, OnAnyShopToggled);
            EventManager.Unregister(PlayerEvents.PlayerInputToggleInventory, PlayerInputToggleInventory);
            EventManager.Unregister<bool>(PlayerEvents.UpdateInventoryItemsButtons, UpdateInventoryUItemsButton);
        }

        private void OnAnyShopToggled(bool value)
        {
            if (value) _isBlockedByOpenShop = true;
            else _isBlockedByOpenShop = false;

            _uiPanel.ToggleCloseButton(!_isBlockedByOpenShop);
            ToggleInventory(value);
        }
   
        private void AddItemToInventory(Item item)
        {
            InstantiateNewInventoryItem(item);
        }
        
        private void AddItemToInventoryBySO(ItemScriptable itemSO)
        {
            InstantiateNewInventoryItemBySO(itemSO);
        }
        
        private void RemoveItemFromInventory(InventoryItem item)
        {
            if (_inventoryItemList.Contains(item))
            {
                _inventoryItemList.Remove(item);
                item.Disable();
            }
        }

        private void InstantiateNewInventoryItem(Item item)
        {
            InstantiateNewInventoryItemBySO(item.ItemScriptable);
        }
        private void InstantiateNewInventoryItemBySO(ItemScriptable itemSO)
        {
            InventoryItem inventoryItem= Instantiate(_inventoryItemPrefab, _inventoryItemParent);
            inventoryItem.SetItemScriptable(itemSO);
            _inventoryItemList.Add(inventoryItem);
            inventoryItem.transform.SetAsFirstSibling();
            inventoryItem.CallInit();
        }
        
        private void PlayerInputToggleInventory()
        {
            TryToggleInventory(!_isOpen, true);
        }

        public void OnCloseButtonClick(bool value)
        {
            TryToggleInventory(value);
        }

        public void TryToggleInventory(bool value, bool openedByPlayer = false)
        {
            if (_isBlockedByOpenShop) return;
            ToggleInventory(value, openedByPlayer);
        }
        private void ToggleInventory(bool value, bool openedByPlayer = false)
        {
            _isOpen = value;
            _uiPanel.ToggleUI(value);
            UpdateInventoryUItemsButton(openedByPlayer);
        }

        public bool CheckIfItemIsEquipped(InventoryItem item)
        {
            switch (item.ItemType)
            {
                case ItemType.Cloth:
                        return CheckIfClothIsEquipped((ClothScriptable)item.ItemScriptable);
                default:
                    break;
            }

            return false;
        }

        private bool CheckIfClothIsEquipped(ClothScriptable clothScriptable)
        {
            switch (clothScriptable.ClothType)
            {
                case ClothType.Hood:
                    return clothScriptable == _currentClothEquipment.Value.Hood;
            
                case ClothType.Shoulder:
                    return clothScriptable == _currentClothEquipment.Value.Shoulder;
            
                case ClothType.Top:
                    return clothScriptable == _currentClothEquipment.Value.Top;
            
                case ClothType.Bottom:
                    return clothScriptable == _currentClothEquipment.Value.Bottom;
            
                default:
                    return false;
            }
        }

        private void UpdateInventoryUItemsButton(bool openedByPlayer)
        {
            _uiPanel.UpdateItemsButtons(openedByPlayer);
        }
    }
}