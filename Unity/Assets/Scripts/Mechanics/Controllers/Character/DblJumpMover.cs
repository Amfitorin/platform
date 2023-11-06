using MyRI.Components.Character;
using MyRI.Configs;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    public class DblJumpMover : JumpMover
    {

        private bool _toDblJumped;
        public DblJumpMover(ICharacterView characterView, CharacterConfig config, Vector2 direction)
            : base(characterView, config, direction)
        {
        }

        protected override void ResetFlags()
        {
            base.ResetFlags();
            _toDblJumped = false;
        }

        public override void Jump()
        {
            base.Jump();
            if (!ToJumped || _toDblJumped)
                return;
            CharacterView.DoubleJump();
            _toDblJumped = true;
        }
    }
}
