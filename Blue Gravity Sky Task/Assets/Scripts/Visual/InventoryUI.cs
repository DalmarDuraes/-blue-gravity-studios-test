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

        public override void ToggleUI(bool value, bool openedByPlayer) 
        {
            base.ToggleUI(value,openedByPlayer);

            if (!value) return;

            var inventoryItemList = _inventory.InventoryItemList;

            foreach (var item in inventoryItemList)
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
