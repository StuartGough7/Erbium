﻿using UnityEngine;
namespace Animators {
    public class CharacterAnimator : MonoBehaviour, ICharacterAnimator {
        private Animator animator;
        private static readonly int InputMagnitude = Animator.StringToHash("inputMagnitude");
        private static readonly int VerInput = Animator.StringToHash("verInput");
        private static readonly int HorInput = Animator.StringToHash("horInput");
        private static readonly int GroundVelocity = Animator.StringToHash("groundVelocity");
        private static readonly int IsFalling = Animator.StringToHash("isFalling");
        private static readonly int IsAboutToLand = Animator.StringToHash("isAboutToLand");

        private void OnEnable() {
            animator = GetComponent<Animator>();
        }

        public void setHorInput(float horInput) {
            animator.SetFloat(HorInput, horInput);
        }

        public void setVerInput(float verInput) {
            animator.SetFloat(VerInput, verInput);
        }

        public void setInputMagnitude(float inputMagnitude) {
            animator.SetFloat(InputMagnitude, inputMagnitude);
        }
        
        public void setGroundVelocity(float groundVelocity) {
            animator.SetFloat(GroundVelocity, groundVelocity);
        }

        public void setIsFalling(bool isFalling) {
            animator.SetBool(IsFalling, isFalling);
        }

        public void setIsAboutToLand(bool isAboutToLand) {
            animator.SetBool(IsAboutToLand, isAboutToLand);
        }
    }
}