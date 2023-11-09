using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace BlueGravityStudios
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryItem _inventoryItemPrefab;
        [SerializeField] private Transform _inventoryItemParent;
        [SerializeField] private UIPanel _uiPanel;
        [SerializeField] private List<InventoryItem> _inventoryItemList = new List<InventoryItem>();

        private void OnEnable()
        {
            EventManager.Register<Item>(PlayerEvents.AddItemToInventory, AddItemToInventory);
            EventManager.Register<InventoryItem>(PlayerEvents.RemoveItemFromInventory, RemoveItemFromInventory);
            EventManager.Register<bool>(NPCEvents.ToggleShop, OnToggleShop); 
        }

        private void OnDisable()
        {
            EventManager.Unregister<Item>(PlayerEvents.AddItemToInventory, AddItemToInventory);
            EventManager.Unregister<InventoryItem>(PlayerEvents.RemoveItemFromInventory, RemoveItemFromInventory);
            EventManager.Unregister<bool>(NPCEvents.ToggleShop, OnToggleShop);
        }

        private void OnToggleShop(bool value)
        {
            _uiPanel.ToggleUI(value);
            if (!value) return;

        }

        private void AddItemToInventory(Item item)
        {
            InstantiateNewInventoryItem(item);
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
            InventoryItem inventoryItem = Instantiate(_inventoryItemPrefab, _inventoryItemParent);
            inventoryItem.SetItemScriptable(item.ItemScriptable);
            _inventoryItemList.Add(inventoryItem);
            inventoryItem.CallInit();
        }
    }
}