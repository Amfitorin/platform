using UnityEngine;

namespace MyRI.Configs
{
    /// <summary>
    /// Character settings
    /// </summary>
    [CreateAssetMenu(menuName = "Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ConfigBase
    {
        /// <summary>
        /// Max character speed
        /// </summary>
        [SerializeField]
        private float _maxSpeed = 8f;

        /// <summary>
        /// Character height speed
        /// </summary>
        [SerializeField]
        private float _flyHeightSpeed = 10f;

        /// <summary>
        /// Character jump force
        /// </summary>
        [SerializeField]
        private float _jumpForce = 700f;

        /// <summary>
        /// Character double jump force
        /// </summary>
        [SerializeField]
        private float _dblForce = 700f;

        /// <summary>
        /// Character seed acceleration
        /// </summary>
        [SerializeField]
        private float _acceleration = 0.03f;

        /// <summary>
        /// Character health
        /// </summary>
        [SerializeField]
        private float _health = 15;

        /// <summary>
        /// Character force for inverse on collide
        /// </summary>
        [SerializeField]
        private int _inverseForce = -50;

        public float MaxSpeed => _maxSpeed;

        public float JumpForce => _jumpForce;

        public float DBLForce => _dblForce;

        public float Acceleration => _acceleration;

        public float Health => _health;

        public int InverseForce => _inverseForce;

        public float FlyHeightSpeed => _flyHeightSpeed;
    }
}
