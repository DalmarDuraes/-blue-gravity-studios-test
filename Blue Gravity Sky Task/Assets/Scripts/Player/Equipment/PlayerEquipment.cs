using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] protected Variable<ClothStruct> _startEquipment;
        private PlayerEquipmentChanger _playerEquipmentChanger;
        private void Awake()
        {
            _playerEquipmentChanger = GetComponent<PlayerEquipmentChanger>();
            
            if(!_playerEquipmentChanger) 
                Debug.LogError($"$ Could not add Player Equipment Changer");
            
            
            CheckStartEquipment();
        }

        private void CheckStartEquipment()
        {
            if (_startEquipment.Value.Hood.ClothType != ClothType.Hood) 
                EquipmentError(_startEquipment.Value.Hood);
            
            else if(_startEquipment.Value.Shoulder.ClothType != ClothType.Shoulder)
                EquipmentError(_startEquipment.Value.Shoulder);
            
            else if(_startEquipment.Value.Top.ClothType != ClothType.Top) 
                EquipmentError(_startEquipment.Value.Top);
            
            else if (_startEquipment.Value.Bottom.ClothType != ClothType.Bottom)
                EquipmentError(_startEquipment.Value.Bottom);

            else
                SetPlayerStartEquipment();
                    
        }

        private void SetPlayerStartEquipment()
        {
            if (_playerEquipmentChanger)
            {
                _playerEquipmentChanger.ChangeEquipment(_startEquipment.Value.Hood);
                _playerEquipmentChanger.ChangeEquipment(_startEquipment.Value.Shoulder);
                _playerEquipmentChanger.ChangeEquipment(_startEquipment.Value.Top);
                _playerEquipmentChanger.ChangeEquipment(_startEquipment.Value.Bottom);
            }
        }

        private void EquipmentError(ClothScriptable equipment)
        {
            Debug.LogError($"$error on: {_startEquipment.Value.Shoulder.ItemName}");
        }

     
    
    }
}

