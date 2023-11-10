using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BlueGravityStudios
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopItem _shopItemPrefab;
        [SerializeField] private Transform _shopItemContainer;
        [SerializeField] protected Variable<int> _PlayerCoins;
        [SerializeField] private UIPanel _uiPanel;
        [SerializeField] protected List<ItemScriptable> _itemScriptableList = new List<ItemScriptable>();
        
        protected List<ShopItem> _shopItemList = new List<ShopItem>();
        private bool _isOpen;

        private void OnEnable()
        {
            EventManager.Register<Item>(EconomyEvents.TryBuyItem, PlayerTryBuyItem);
            EventManager.Register<Item>(EconomyEvents.SellItem, PlayerTrySellItem);
        }

        private void OnDisable()
        {
            EventManager.Unregister<Item>(EconomyEvents.TryBuyItem, PlayerTryBuyItem);
            EventManager.Unregister<Item>(EconomyEvents.SellItem, PlayerTrySellItem);
        }
        
        private void Awake()
        {
            PopulateShop();
        }

        private void PopulateShop()
        {
            foreach (var itemScriptable in _itemScriptableList)
            {
                AddItemToShop(itemScriptable);
            }
        }

        private void PlayerTryBuyItem(Item item)
        {
            if (item.ItemPrice > _PlayerCoins.Value) return;
            BuyItem(item);
        }

        private void PlayerTrySellItem(Item item)
        {
            SellItem(item);
        }

        private void BuyItem(Item item)
        {
           EventManager.Trigger<Item>(PlayerEvents.AddItemToInventory, item);
           EventManager.Trigger<int>(EconomyEvents.ReduceCoins, item.ItemPrice);
           RemoveItemFromList((ShopItem)item);
        }

        private void RemoveItemFromList(ShopItem item)
        {
            if (_shopItemList.Contains(item))
            {
                _shopItemList.Remove(item);
                item.Disable();
            }
        }

        protected void SellItem(Item item)
        {
            AddItemToShop(item.ItemScriptable);
            EventManager.Trigger<InventoryItem>(PlayerEvents.RemoveItemFromInventory, (InventoryItem)item);
            EventManager.Trigger<int>(EconomyEvents.AddCoins, item.ItemSellPrice);
        }

        private void AddItemToShop(ItemScriptable itemScriptable)
        {
            var shopItem = Instantiate(_shopItemPrefab, _shopItemContainer);
            shopItem.SetItemScriptable(itemScriptable);
            shopItem.CallInit();
            _shopItemList.Add(shopItem);
        }

        public void TryToggleShop(bool value)
        {
            if (value == _isOpen) return; 
            ToggleShop(value);
        }


        private void ToggleShop(bool value)
        {
            _isOpen = value;
            EventManager.Trigger<bool>(NPCEvents.ToggleShop, _isOpen); 
            _uiPanel.ToggleUI(value);
        }
    }
}
