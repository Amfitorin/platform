using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.Controllers.InputControllers;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    /// <summary>
    /// player mover with jump
    /// </summary>
    public class JumpMover : CharacterMover
    {
        /// <summary>
        /// controller for jump buttons
        /// </summary>
        private readonly JumpInputController _inputController;
        
        /// <summary>
        /// flag for current jump state
        /// </summary>
        protected bool ToJumped;
        public JumpMover(ICharacterView characterView, CharacterConfig config, Vector2 direction, float speed)
            : base(characterView, config, direction, speed)
        {
            _inputController = new JumpInputController();
            _inputController.JumpEvent += OnJumpEvent;
        }

        public override void Dispose()
        {
            base.Dispose();
            _inputController.JumpEvent -= OnJumpEvent;
        }

        public virtual void Jump()
        {
            if (!CharacterView.Grounded || ToJumped)
                return;
            CharacterView.Jump();
            ToJumped = true;
        }

        public override void Update()
        {
            base.Update();
            _inputController.CheckInput();

            if (ToJumped && CharacterView.Grounded)
            {
                ResetFlags();
            }
        }

        private void OnJumpEvent()
        {
            Jump();
        }
        protected virtual void ResetFlags()
        {
            CharacterView.ToGround();
            ToJumped = false;
        }
    }
}
