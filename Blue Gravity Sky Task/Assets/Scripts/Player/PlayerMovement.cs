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
        [SerializeField] private Animator _playerAnimator;
        
        private PlayerInput _playerInput;
        private Rigidbody2D _rb2D;
        private PlayerInputAction playerInputAction;
        private Vector2 _inputVector;
        private Vector3 _standardScale;
        private Vector3 _flippedScale;
        private bool _canMove = true;
        private bool _isFlipped;
        private void OnEnable()
        {
            EventManager.Register<bool>(PlayerEvents.ToggleCanMove,  ToggleCanMove);
        }

        private void OnDisable()
        {
            EventManager.Unregister<bool>(PlayerEvents.ToggleCanMove, ToggleCanMove);
        }

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rb2D = GetComponent<Rigidbody2D>();
            playerInputAction = new PlayerInputAction();
            playerInputAction.PlayerActionMap.Enable();
            
            _standardScale = transform.localScale;
            _flippedScale = _standardScale;
            _flippedScale.x *= -1;
        }

        private void FixedUpdate()
        {
            
            if (!_canMove)
            {
                _playerAnimator.SetBool("Walking",false);
                _rb2D.velocity = Vector2.zero;
                return;
            }
            
            _inputVector = playerInputAction.PlayerActionMap.PlayerMovement.ReadValue<Vector2>();
            
            if (_inputVector.x == 0 && _inputVector.y == 0)
                _playerAnimator.SetBool("Walking",false);
            else
                _playerAnimator.SetBool("Walking",true);
            
            
            if (_inputVector.x < 0 && !_isFlipped)
            {
                transform.localScale = _flippedScale;
                _isFlipped = true;
            }
            
            else if(_inputVector.x > 0 && _isFlipped)
            {
                transform.localScale = _standardScale;
                _isFlipped = false;
            }
            
            _rb2D.velocity = _inputVector * _speed;
        }
        
        private void ToggleCanMove(bool value)
        {
            _canMove = value;
        }
    }
}
