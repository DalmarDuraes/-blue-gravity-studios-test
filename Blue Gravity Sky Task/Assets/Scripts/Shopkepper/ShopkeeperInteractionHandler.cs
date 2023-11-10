using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BlueGravityStudios
{
    public class ShopkeeperInteractionHandler : MonoBehaviour, IInteractable
    {
        private PlayerController _player;
        
        [SerializeField] private ShopkeeperInteractionVisual _shopkeeperInteractionVisual;
        [Tooltip("Minimum distance from the player to enable interaction")] 
        [SerializeField] private float _minDistanceToInteract;

        [SerializeField] private bool _canInteract;

        private void OnEnable()
        {
            EventManager.Register(PlayerEvents.PlayerInputNpcInteraction, Interact);
        }

        private void OnDisable()
        {
            EventManager.Unregister(PlayerEvents.PlayerInputNpcInteraction, Interact);
        }

        private void Start()
        {
            if (!_player)
            {
                RequestPlayer();
            }
        }

        private void Update()
        {
            if (!CheckIfCanEnableInteraction())
            {
                if (!_canInteract) return;
                ToggleInteractionTooltip(false);
            }

            else
            {
                if (_canInteract) return;
                ToggleInteractionTooltip(true);
            }

        }

        private void ToggleInteractionTooltip(bool value)
        {
            _canInteract = value;
            _shopkeeperInteractionVisual.ToggleInteractionTooltip(value);
        }
        public void Interact()
        {
            if (!_canInteract) return;
            
            TryToggleShop();
        }

        private void TryToggleShop()
        {
            _shopkeeperInteractionVisual.TryToggleShop();
        }
        
        private float CalculateDistanceFromPlayer()
        {
            if (!_player) RequestPlayer();
            
            return Vector3.Distance(transform.position, _player.transform.position);
        }

        private bool CheckIfCanEnableInteraction() => CalculateDistanceFromPlayer() <= _minDistanceToInteract;
        private void OnGetPlayer(PlayerController player) => _player = player;

        private void RequestPlayer()
        {
            EventManager.TriggerReturn<PlayerController>(PlayerEvents.GetPlayer, OnGetPlayer);
        }


   
    }
}
