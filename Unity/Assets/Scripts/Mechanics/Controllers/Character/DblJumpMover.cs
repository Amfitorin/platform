using MyRI.Components.Character;
using MyRI.Configs;
using UnityEngine;

namespace MyRI.Mechanics.Controllers.Character
{
    /// <summary>
    /// mover with double jump 
    /// </summary>
    public class DblJumpMover : JumpMover
    {

        /// <summary>
        /// flag for current double jump state
        /// </summary>
        private bool _toDblJumped;
        public DblJumpMover(ICharacterView characterView, CharacterConfig config, Vector2 direction, float speed)
            : base(characterView, config, direction, speed)
        {
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

        protected override void ResetFlags()
        {
            base.ResetFlags();
            _toDblJumped = false;
        }
    }
}
