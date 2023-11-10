using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class InventoryUI : UIPanel
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private GameObject _closeButton;
        
        public void ToggleCloseButton(bool value) => _closeButton.SetActive(value);
   
        public void UpdateItemsButtons(bool openedByPlayer)
        {
            foreach (var item in _inventory.InventoryItemList)
            {
                var alreadyEquipped = _inventory.CheckIfItemIsEquipped(item);
                if (openedByPlayer)
                {
                    item.ActiveEquipBtn(alreadyEquipped);
                }
                else
                    item.ActiveSellBtn(alreadyEquipped);
            }
        }
     
    }
}
