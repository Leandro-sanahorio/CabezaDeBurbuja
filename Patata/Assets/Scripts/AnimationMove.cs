using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Scripts

    /// AnimationMove integra las fisicas y animación. Se usa generalmente para la animación de un enemigo simple.
 
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
    public class AnimationController : KinematicObject
    {

        /// Velocidad maxima horizontal

        public float maxSpeed = 7;

        /// Velocidad maxima de salto
    
        public float jumpTakeOffSpeed = 7;


        /// Se usa para indicar la dirección deseada.

        public Vector2 move;


        /// True para iniciar un salto.

        public bool jump;


        /// True para setear la velocidad actual de salto a cero.
        public bool stopJump;

        SpriteRenderer spriteRenderer;
        Animator animator;
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }
    }