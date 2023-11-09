using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class EconomyManager : MonoBehaviour
    {
        [SerializeField] private Variable<int> _coin;
        private int _currentCoins;
        
        private void OnEnable()
        {
            EventManager.RegisterReturn(EconomyEvents.GetCurrentCoins, GetCurrentCoins);
            EventManager.Register<int>(EconomyEvents.AddCoins, AddCoins);
            EventManager.Register<int>(EconomyEvents.ReduceCoins, ReduceCoins);
        }

        private void OnDisable()
        {
            EventManager.UnregisterReturn(EconomyEvents.GetCurrentCoins, GetCurrentCoins);
            EventManager.Unregister<int>(EconomyEvents.AddCoins, AddCoins);
            EventManager.Unregister<int>(EconomyEvents.ReduceCoins, ReduceCoins);
        }

        private void Awake()
        {
            TriggerUpdateCoinTxt();
        }

        private void AddCoins(int value)
        {
            _coin.Value += value;
            TriggerUpdateCoinTxt();
        }
        
        private void ReduceCoins(int value)
        {
            _coin.Value -= value;
            TriggerUpdateCoinTxt();
        }
        
        private void TriggerUpdateCoinTxt() => EventManager.Trigger(EconomyEvents.UpdateCoinValueVisual);

        private int GetCurrentCoins() => _currentCoins;

    }
}
