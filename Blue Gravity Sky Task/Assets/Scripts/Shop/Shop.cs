using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BlueGravityStudios
{
    public class Shop : MonoBehaviour
    {
        [FormerlySerializedAs("_shopItemPrefab")] [SerializeField] private ShopItem shopItemOnUiBasePrefab;
        [SerializeField] private Transform _shopItemContainer;
        [SerializeField] protected Variable<int> _PlayerCoins;
        [SerializeField] private UIPanel _uiPanel;
        [SerializeField] protected List<ItemScriptable> _itemScriptableList = new List<ItemScriptable>();
        [SerializeField] protected List<ShopItem> _shopItemList = new List<ShopItem>();
        private bool _isOpen;

        private void OnEnable()
        {
            EventManager.Register<ItemOnUiBase>(EconomyEvents.TryBuyItem, PlayerTryBuyItem);
            EventManager.Register<ItemOnUiBase>(EconomyEvents.SellItem, PlayerTrySellItem);
        }

        private void OnDisable()
        {
            EventManager.Unregister<ItemOnUiBase>(EconomyEvents.TryBuyItem, PlayerTryBuyItem);
            EventManager.Unregister<ItemOnUiBase>(EconomyEvents.SellItem, PlayerTrySellItem);
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

        private void PlayerTryBuyItem(ItemOnUiBase itemOnUiBase)
        {
            if (itemOnUiBase.ItemPrice > _PlayerCoins.Value) return;
            BuyItem(itemOnUiBase);
        }

        private void PlayerTrySellItem(ItemOnUiBase itemOnUiBase)
        {
            SellItem(itemOnUiBase);
        }

        private void BuyItem(ItemOnUiBase itemOnUiBase)
        {
           EventManager.Trigger<ItemOnUiBase>(PlayerEvents.AddItemToInventory, itemOnUiBase);
           EventManager.Trigger<int>(EconomyEvents.ReduceCoins, itemOnUiBase.ItemPrice);
           RemoveItemFromList((ShopItem)itemOnUiBase);
        }

        private void RemoveItemFromList(ShopItem itemOnUiBase)
        {
            if (_shopItemList.Contains(itemOnUiBase))
            {
                _shopItemList.Remove(itemOnUiBase);
                itemOnUiBase.Disable();
            }
        }

        protected void SellItem(ItemOnUiBase itemOnUiBase)
        {
            AddItemToShop(itemOnUiBase.ItemScriptable);
            EventManager.Trigger<InventoryItem>(PlayerEvents.RemoveItemFromInventory, (InventoryItem)itemOnUiBase);
            EventManager.Trigger<int>(EconomyEvents.AddCoins, itemOnUiBase.ItemSellPrice);
        }

        private void AddItemToShop(ItemScriptable itemScriptable)
        {
            var shopItem = Instantiate(shopItemOnUiBasePrefab, _shopItemContainer);
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
