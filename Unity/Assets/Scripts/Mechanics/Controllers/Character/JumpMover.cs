using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.Controllers.InputControllers;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    public class JumpMover : CharacterMover
    {
        protected bool ToJumped;

        private readonly JumpInputController _inputController;
        public JumpMover(ICharacterView characterView, CharacterConfig config, Vector2 direction)
            : base(characterView, config, direction)
        {
            _inputController = new JumpInputController();
            _inputController.JumpEvent += OnJumpEvent;
        }

        private void OnJumpEvent()
        {
            Jump();
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
        protected virtual void ResetFlags()
        {
            CharacterView.ToGround();
            ToJumped = false;
        }

        public virtual void Jump()
        {
            if (!CharacterView.Grounded || ToJumped)
                return;
            CharacterView.Jump();
            ToJumped = true;
        }

        public override void Dispose()
        {
            base.Dispose();
            _inputController.JumpEvent -= OnJumpEvent;
        }
    }
}
