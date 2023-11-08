using System;
using UnityEngine;

namespace MyRI.Components.Character
{
    /// <summary>
    /// Configuration names for character Animator states. For use to setup MonoBehaviour settings
    /// </summary>
    [Serializable]
    public class AnimationStates
    {
        /// <summary>
        /// State when character move on ground
        /// </summary>
        [SerializeField]
        private string _groundState = "ToGround";

        /// <summary>
        /// State when character move in car
        /// </summary>
        [SerializeField]
        private string _carState = "ToCar";

        /// <summary>
        /// State when character is scary
        /// </summary>
        [SerializeField]
        private string _scaryState = "Scarry";

        /// <summary>
        /// State when character is death
        /// </summary>
        [SerializeField]
        private string _deathState = "Death";

        /// <summary>
        /// State when character is Jumped
        /// </summary>
        [SerializeField]
        private string _jumpState = "ToJump";

        public string GroundState => _groundState;

        public string CarState => _carState;

        public string ScaryState => _scaryState;

        public string DeathState => _deathState;

        public string JumpState => _jumpState;
    }
}
