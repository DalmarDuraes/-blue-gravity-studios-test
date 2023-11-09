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
        [FormerlySerializedAs("_inventoryItemPrefab")] [SerializeField] private InventoryItem inventoryItemOnUiBasePrefab;
        [SerializeField] private Transform _inventoryItemParent;
        [SerializeField] private InventoryUI _uiPanel;
        
        [SerializeField] private List<InventoryItem> _inventoryItemList = new List<InventoryItem>();
        public List<InventoryItem> InventoryItemList => _inventoryItemList;
        
        private bool _isOpen;
        private bool _isBlockedByOpenShop;
        
        private void OnEnable()
        {
            EventManager.Register<ItemOnUiBase>(PlayerEvents.AddItemToInventory, AddItemToInventory);
            EventManager.Register<InventoryItem>(PlayerEvents.RemoveItemFromInventory, RemoveItemFromInventory);
            EventManager.Register<bool>(NPCEvents.ToggleShop, OnAnyShopToggled); 
            EventManager.Register(PlayerEvents.PlayerInputToggleInventory, PlayerInputToggleInventory);
        }

        private void OnDisable()
        {
            EventManager.Unregister<ItemOnUiBase>(PlayerEvents.AddItemToInventory, AddItemToInventory);
            EventManager.Unregister<InventoryItem>(PlayerEvents.RemoveItemFromInventory, RemoveItemFromInventory);
            EventManager.Unregister<bool>(NPCEvents.ToggleShop, OnAnyShopToggled);
            EventManager.Unregister(PlayerEvents.PlayerInputToggleInventory, PlayerInputToggleInventory);
        }
        private void OnAnyShopToggled(bool value)
        {
            if (value) _isBlockedByOpenShop = true;
            else _isBlockedByOpenShop = false;

            _uiPanel.ToggleCloseButton(!_isBlockedByOpenShop);
            ToggleInventory(value);
        }
   
        private void AddItemToInventory(ItemOnUiBase itemOnUiBase)
        {
            InstantiateNewInventoryItem(itemOnUiBase);
        }
        private void RemoveItemFromInventory(InventoryItem itemOnUiBase)
        {
            if (_inventoryItemList.Contains(itemOnUiBase))
            {
                _inventoryItemList.Remove(itemOnUiBase);
                itemOnUiBase.Disable();
            }
        }

        private void InstantiateNewInventoryItem(ItemOnUiBase itemOnUiBase)
        {
            InventoryItem inventoryItemOnUiBase = Instantiate(inventoryItemOnUiBasePrefab, _inventoryItemParent);
            inventoryItemOnUiBase.SetItemScriptable(itemOnUiBase.ItemScriptable);
            _inventoryItemList.Add(inventoryItemOnUiBase);
            inventoryItemOnUiBase.CallInit();
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
            _uiPanel.ToggleUI(value, openedByPlayer);
        }
    }
}