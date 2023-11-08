using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using MyRI.Configs;
using MyRI.Configs.Collectables;
using UnityEngine;

namespace MyRI.Components.Character
{
    public class CharacterViewComponent : MonoBehaviour, ICharacterView
    {
        [SerializeField]
        private Transform _groundCheck;

        [SerializeField]
        private float _groundRadius = 0.2f;

        [SerializeField]
        private LayerMask _whatIsGround;

        [SerializeField]
        private CharacterConfig _config;

        [SerializeField]
        private Rigidbody2D _rig2d;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private PlayerCAr _car;

        [SerializeField]
        private AnimationStates _states;

        private bool _started;
        private bool _collided;
        private float _currentHealth;
        private bool _grounded;
        private bool _inCar;
        private MapSpawner _spawner;

        public bool Started => _started;


        public MapSpawner Spawner
        {
            get => _spawner;
            set
            {
                _spawner = value;
                Spawner.Starter.HUD.PLayer.SetMax(_config.Health);
            }
        }

        private async void Awake()
        {
            _currentHealth = _config.Health;

            await StartGame(2);
        }

        public void UpdateCollides(Vector2 mainDirection)
        {
            if (!_started)
                return;
            _grounded = Math.Abs(_rig2d.velocity.y) < 0.01 &&
                        Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundRadius, _whatIsGround);

            var raycast = Physics2D.Raycast(transform.position, mainDirection, _groundRadius, _whatIsGround);

            var distance = raycast.distance;
            _collided = raycast.transform != null && distance < _groundRadius;
        }
        public void ApplyPosition(Vector2 position)
        {
            transform.position = position;
        }
        public void DisableGravity(bool state)
        {
            _rig2d.gravityScale = state ? 0f : 1f;
        }

        public void Jump()
        {
            _rig2d.AddForce(new Vector2(0f, _config.JumpForce));
            _animator.SetTrigger(_states.JumpState);
            _rig2d.velocity = new Vector2(_rig2d.velocity.x, 0.1f);
        }
        public bool Grounded => _grounded;
        public bool Collided => _collided;
        public Vector2 Position => transform.position;
        public void ApplyVelocity(float velocity)
        {
            var rbVelocity = new Vector2(velocity, _rig2d.velocity.y);
            _rig2d.velocity = rbVelocity;
        }
        public void Collide(Vector2 direction)
        {
            _rig2d.AddForce(direction * _config.InverseForce);
        }
        public void ToGround()
        {
            _animator.SetTrigger(_states.GroundState);
        }

        public void DoubleJump()
        {
            _rig2d.AddForce(new Vector2(0f, _config.DBLForce));
            DOTween.To(() => Vector3.zero, x => transform.eulerAngles = x, new Vector3(0, 0, -360), 0.5f);
        }

        private async Task StartGame(int seconds)
        {
            await Task.Delay(seconds * 1000);
            _started = true;
        }

        public void ApplyDamage(float damage)
        {
            if (Mathf.Approximately(0f, damage))
            {
                return;
            }

            _animator.SetTrigger(_states.ScaryState);
            _currentHealth -= damage;
            Spawner.Starter.HUD.PLayer.ApplyDamage(damage);
            if (_currentHealth <= 0)
            {
                _animator.SetTrigger(_states.DeathState);
                GameOver();
            }
        }

        private void GameOver()
        {
            Spawner.Starter.OpenPopup(_spawner.Starter.HUD, false);
            _started = false;
            Time.timeScale = 0f;
            Spawner.Starter.OpenPopup(Spawner.Starter.Fail, true);
        }

        public async void Win()
        {
            Spawner.Starter.OpenPopup(_spawner.Starter.HUD, false);
            _started = false;
            await WaitClose();
        }

        private async Task WaitClose()
        {
            await Task.Delay(3000);
            Time.timeScale = 0f;
            Spawner.Starter.OpenPopup(Spawner.Starter.Vic, true);
        }
    }
}
