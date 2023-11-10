using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BlueGravityStudios
{
    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] protected Variable<ClothStruct> _starClothEquipment;
        [SerializeField] protected Variable<ClothStruct> _currentClothEquipment;
        private ClothStruct _currentClothStruct = new ClothStruct();
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
            if (_starClothEquipment.Value.Hood.ClothType != ClothType.Hood) 
                EquipmentError(_starClothEquipment.Value.Hood);
            
            else if(_starClothEquipment.Value.Shoulder.ClothType != ClothType.Shoulder)
                EquipmentError(_starClothEquipment.Value.Shoulder);
            
            else if(_starClothEquipment.Value.Top.ClothType != ClothType.Top) 
                EquipmentError(_starClothEquipment.Value.Top);
            
            else if (_starClothEquipment.Value.Bottom.ClothType != ClothType.Bottom)
                EquipmentError(_starClothEquipment.Value.Bottom);

            else
                SetPlayerStartEquipment();
        }

        private void SetPlayerStartEquipment()
        {
            if (_playerEquipmentChanger)
            {
                _currentClothStruct = _starClothEquipment.Value;
                _currentClothEquipment.Value = _currentClothStruct;
                
                _allEquippedEquipment.Add(_currentClothStruct.Hood);
                _allEquippedEquipment.Add(_currentClothStruct.Shoulder);
                _allEquippedEquipment.Add(_currentClothStruct.Top);
                _allEquippedEquipment.Add(_currentClothStruct.Bottom);

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

