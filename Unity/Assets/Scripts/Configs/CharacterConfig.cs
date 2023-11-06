using UnityEngine;

namespace MyRI.Configs
{
    [CreateAssetMenu( menuName = "Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ConfigBase
    {
        [SerializeField]
        private float _maxSpeed = 8f;
        
        [SerializeField]
        private float _jumpForce = 700f;
        
        [SerializeField]
        private float _dblForce = 700f;
        
        [SerializeField]
        private float _acceleration = 0.03f;

        [SerializeField]
        private float _health = 15;
        
        [SerializeField]
        private int _inverseForce = -50;

        public float MaxSpeed => _maxSpeed;

        public float JumpForce => _jumpForce;

        public float DBLForce => _dblForce;

        public float Acceleration => _acceleration;

        public float Health => _health;

        public int InverseForce => _inverseForce;
    }
}
