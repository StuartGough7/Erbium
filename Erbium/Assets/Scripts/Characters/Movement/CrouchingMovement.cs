﻿using System;
using Animators;
using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class CrouchingMovement : IMovement, IFallable, IJumpable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;
        private readonly IAnimatorFacade animatorFacade;

        public CrouchingMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
            animatorFacade = character.getAnimatorFacade();
            animatorFacade.setCrouching(true);
        }


        public void setUp() {
            animatorFacade.setCrouching(true);
        }

        public void move(Vector3 direction) {
            if (isFalling()) {
                changeMovement(MovementEnum.Midair);
                return;
            }

            var velocity =
                CommonMethods.createVectorWithoutLoosingY(direction, rbd.velocity.y, character.getStats().CrouchSpeed);

            rbd.velocity = velocity;
            rotate(direction);
            updateAnimParameters();
        }


        private void rotate(Vector3 direction) {
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    character.getStats().RotationSpeed);
            }
        }

        private void updateAnimParameters() {
            animatorFacade.updateInputs();
        }

        public void changeMovement(MovementEnum movement) {
            character.changeMovement(movement);
        }

        public void cleanUp() {
            animatorFacade.setCrouching(false);
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform.position);
        }

        public void jump() {
            animatorFacade.setJumping(true);
            rbd.AddForce(Vector3.up * character.getStats().JumpForce, ForceMode.Impulse);
        }
    }
}