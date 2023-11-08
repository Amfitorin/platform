using MyRI.Components.Character;
using MyRI.Configs;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    public class DblJumpMover : JumpMover
    {

        private bool _toDblJumped;
        public DblJumpMover(ICharacterView characterView, CharacterConfig config, Vector2 direction, float speed)
            : base(characterView, config, direction, speed)
        {
        }

        protected override void ResetFlags()
        {
            base.ResetFlags();
            _toDblJumped = false;
        }

        public override void Jump()
        {
            if (ToJumped && !_toDblJumped)
            {
                CharacterView.DoubleJump();
                _toDblJumped = true;
            }
            base.Jump();
        }
    }
}
