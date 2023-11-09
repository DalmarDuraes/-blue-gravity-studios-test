using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlueGravityStudios
{
    public class InventoryItem: ItemOnUiBase
    {
        [SerializeField] private GameObject _sellBtn;
        [SerializeField] private GameObject _equipItemBtn;
        [SerializeField] private GameObject _pricePanel;
        
        protected override void Init()
        {
            base.Init();
            _itemPriceTxt.text = _itemSellPrice.ToString();
        }

        public void SellItem()
        {
            EventManager.Trigger<ItemOnUiBase>(EconomyEvents.SellItem, this);
        }
        public void TryEquipItem()
        {
            EventManager.Trigger<ItemOnUiBase>(PlayerEvents.EquipItem, this);
        }

        public void ActiveEquipBtn()
        {
            _equipItemBtn.SetActive(true);
            _sellBtn.SetActive(false);
            _pricePanel.SetActive(false);
        }
        
        public void ActiveSellBtn()
        {
            _equipItemBtn.SetActive(false);
            _sellBtn.SetActive(true);
            _pricePanel.SetActive(true);

        }


    }
}