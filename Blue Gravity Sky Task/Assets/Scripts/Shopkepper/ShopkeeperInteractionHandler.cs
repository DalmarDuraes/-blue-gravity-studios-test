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
        
        [Tooltip("Minimum distance from the player to enable interaction")] 
        [SerializeField] private float _minDistanceToInteract;

        [SerializeField] private bool _canInteract;

        private void OnEnable()
        {
            EventManager.Register(PlayerEvents.PlayerPressedNpcInteraction, Interact);
        }

        private void OnDisable()
        {
            EventManager.Unregister(PlayerEvents.PlayerPressedNpcInteraction, Interact);
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
                HandleInteraction(false);
            }

            else
            {
                if (_canInteract) return;
                HandleInteraction(true);
            }

        }

        private void HandleInteraction(bool value)
        {
            _canInteract = value;
            EventManager.Trigger(ShopkeeperEvents.ToggleBalloonVisualFeedback,value);
        }
        public void Interact()
        {
            if (!_canInteract) return;
            Debug.Log("a");
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
