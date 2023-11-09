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
        [SerializeField] private List<ItemScriptable> _itemScriptableList = new List<ItemScriptable>();

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
    }
}
