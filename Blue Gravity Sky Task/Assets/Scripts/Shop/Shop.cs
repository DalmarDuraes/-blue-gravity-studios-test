using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopItem _shopItemPrefab;
        [SerializeField] private Transform _shopItemContainer;
        [SerializeField] protected List<ItemScriptable> _itemScriptableList = new List<ItemScriptable>();

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
                var shopItem = Instantiate(_shopItemPrefab, _shopItemContainer);
                shopItem.SetItemScriptable(itemScriptable);
            }
        }

        private void PlayerTryBuyItem(Item item)
        {
            int currentCoins = 0;
           EventManager.TriggerReturn<int>(EconomyEvents.GetCurrentCoins, GetCurrentCoins );
           
           void GetCurrentCoins(int value) => currentCoins = value;

           if (item.ItemPrice > currentCoins) return;
           
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
        }

        protected void SellItem(Item item)
        {
           EventManager.Trigger<Item>(PlayerEvents.RemoveItemFromInventory, item);
        }

     
    }
}
