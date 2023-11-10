using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace BlueGravityStudios
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private PlayerInput _playerInput;
        private Rigidbody2D _rb2D;
        private PlayerInputAction playerInputAction;
        private Vector2 _inputVector;
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rb2D = GetComponent<Rigidbody2D>();
            playerInputAction = new PlayerInputAction();
            playerInputAction.PlayerActionMap.Enable();
        }

        private void FixedUpdate()
        {
            _inputVector = playerInputAction.PlayerActionMap.PlayerMovement.ReadValue<Vector2>();
            _rb2D.velocity = _inputVector * _speed;
        }

    
        
        
        
    }
}
