using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class InfoUiAnimatorHandle : MonoBehaviour
    {
        [SerializeField] private AnimationClip _uiAnin;
        private Animator _animator;
        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(_uiAnin.name);
            
        }

        public void PlayAnim()
        {
            _animator.Play(_uiAnin.name);
        }
    }
}
