using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class ChangeEquipmentSystem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _hood;
        [SerializeField] private SpriteRenderer _shoulderL;
        [SerializeField] private SpriteRenderer _shoulderR;

        [SerializeField] private Sprite _currentHood;
        [SerializeField] private Sprite _currentShoulderL;
        [SerializeField] private Sprite _currentShoulderR;

        private void Awake()
        {
            _currentHood = _hood.sprite;
            _currentShoulderL = _shoulderL.sprite;
            _currentShoulderR = _shoulderR.sprite;
        }

        private void ChangeEquipment()
        {

        }
    }
}
