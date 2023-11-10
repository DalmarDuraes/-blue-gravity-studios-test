using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlueGravityStudios
{
    public class InventoryItem: Item
    {
        [SerializeField] private GameObject _sellBtn;
        [SerializeField] private GameObject _equipItemBtn;
        [SerializeField] private GameObject _equippedItemBtn;
        [SerializeField] private GameObject _pricePanel;
        
        protected override void Init()
        {
            base.Init();
            _itemPriceTxt.text = _itemSellPrice.ToString();
        }

        public void SellItem()
        {
            EventManager.Trigger<Item>(EconomyEvents.SellItem, this);
        }
        public void TryEquipItem()
        {
            EventManager.Trigger<Item>(PlayerEvents.EquipItem, this);
        }

        public void ActiveEquipBtn(bool alreadyEquipped)
        {
            
            _sellBtn.gameObject.SetActive(false);
            _pricePanel.SetActive(false);

            Debug.Log(alreadyEquipped);
            if (alreadyEquipped)
            {
                _equipItemBtn.SetActive(false);
                _equippedItemBtn.SetActive(true);
            }
            else
            {
                _equipItemBtn.SetActive(true);
                _equippedItemBtn.SetActive(false);
                
            }
        }
        
        public void ActiveSellBtn(bool alreadyEquipped)
        {
            _equippedItemBtn.SetActive(false);
            _equipItemBtn.SetActive(false);
            _sellBtn.SetActive(true);
            _pricePanel.SetActive(true);
            if (alreadyEquipped)
            {
                _sellBtn.SetActive(false);
                _equippedItemBtn.SetActive(true);
            }

        }


    }
}