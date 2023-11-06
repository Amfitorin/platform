using System;
using UnityEngine;

namespace MyRI.Components.Character
{
    [Serializable]
    public class AnimationStates
    {
        [SerializeField]
        private string _groundState = "ToGround";

        [SerializeField]
        private string _carState = "ToCar";
        
        [SerializeField]
        private string _scaryState = "Scarry";
        
        [SerializeField]
        private string _deathState = "Death";

        [SerializeField]
        private string _jumpState = "ToJump";

        public string GroundState => _groundState;

        public string CarState => _carState;

        public string ScaryState => _scaryState;

        public string DeathState => _deathState;

        public string JumpState => _jumpState;
    }
}
