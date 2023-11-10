using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] protected Variable<ClothStruct> _starClothtEquipment;
        private PlayerEquipmentChanger _playerEquipmentChanger;
        private bool _starterEquipmentBlocked;
        private List<ItemScriptable> _allEquippedEquipment = new List<ItemScriptable>();
        
        private void Awake()
        {
            _playerEquipmentChanger = GetComponent<PlayerEquipmentChanger>();
            
            if(!_playerEquipmentChanger) 
                Debug.LogError($"$ Could not add Player Equipment Changer");
            
            CheckStartEquipment();
        }

        private void Start()
        {
            if (_starterEquipmentBlocked) return;
            AddStartEquipmentToInventory();
        }

        private void CheckStartEquipment()
        {
            if (_starClothtEquipment.Value.Hood.ClothType != ClothType.Hood) 
                EquipmentError(_starClothtEquipment.Value.Hood);
            
            else if(_starClothtEquipment.Value.Shoulder.ClothType != ClothType.Shoulder)
                EquipmentError(_starClothtEquipment.Value.Shoulder);
            
            else if(_starClothtEquipment.Value.Top.ClothType != ClothType.Top) 
                EquipmentError(_starClothtEquipment.Value.Top);
            
            else if (_starClothtEquipment.Value.Bottom.ClothType != ClothType.Bottom)
                EquipmentError(_starClothtEquipment.Value.Bottom);

            else
                SetPlayerStartEquipment();
        }

        private void SetPlayerStartEquipment()
        {
            if (_playerEquipmentChanger)
            
            {
                _allEquippedEquipment.Add(_starClothtEquipment.Value.Hood);
                _allEquippedEquipment.Add(_starClothtEquipment.Value.Shoulder);
                _allEquippedEquipment.Add(_starClothtEquipment.Value.Top);
                _allEquippedEquipment.Add(_starClothtEquipment.Value.Bottom);

                foreach (var item in _allEquippedEquipment)
                {
                    _playerEquipmentChanger.ChangeEquipment(item);
                }
            }
        }

        private void AddStartEquipmentToInventory()
        {
            foreach (var item in _allEquippedEquipment)
            {
                EventManager.Trigger<ItemScriptable>(PlayerEvents.AddItemToInventoryBySO, item);
            }
        }
        
        private void EquipmentError(ClothScriptable equipment)
        {
            _starterEquipmentBlocked = true;
            Debug.LogError($"$error setting equipment");
        }

     
    
    }
}

