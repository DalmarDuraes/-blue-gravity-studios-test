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
        [SerializeField] private List<ShopItemScriptable> _shopItemScriptableList = new List<ShopItemScriptable>();

        private void Awake()
        {
            PopulateShop();
        }

        private void PopulateShop()
        {
            foreach (var shopItemScriptable in _shopItemScriptableList)
            {
                var shopItem = Instantiate(_shopItemPrefab, _shopItemContainer);
                shopItem.SetShopItemScriptable(shopItemScriptable);
            }
        }
    }
}
