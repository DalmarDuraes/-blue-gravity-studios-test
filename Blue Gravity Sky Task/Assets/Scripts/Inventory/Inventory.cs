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
        [SerializeField] private List<InventoryItem> _inventoryItemList = new List<InventoryItem>();

        private void OnEnable()
        {
            EventManager.Register<Item>(PlayerEvents.AddItemToInventory, AddItemToInventory);
            EventManager.Register<Item>(PlayerEvents.RemoveItemFromInventory, RemoveItemFromInventory);
        }

        private void OnDisable()
        {
            EventManager.Unregister<Item>(PlayerEvents.AddItemToInventory, AddItemToInventory);
            EventManager.Unregister<Item>(PlayerEvents.RemoveItemFromInventory, RemoveItemFromInventory);
        }

        private void AddItemToInventory(Item item)
        {
            InstantiateNewInventoryItem(item);
        }
        private void RemoveItemFromInventory(Item item)
        {
            throw new NotImplementedException();
        }

        private void InstantiateNewInventoryItem(Item item)
        {
            InventoryItem inventoryItem = Instantiate(_inventoryItemPrefab, _inventoryItemParent);
            inventoryItem.SetItemScriptable(item.ItemScriptable);
            _inventoryItemList.Add(inventoryItem);
        }
    }
}