using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class InventoryUI : UIPanel
    {
        [SerializeField] private GameObject _closeButton;

        public void ToggleCloseButton(bool value) => _closeButton.SetActive(value);
    }
}
