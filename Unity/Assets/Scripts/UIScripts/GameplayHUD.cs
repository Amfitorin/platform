using System;
using MyRI.Components.Collectables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyRI.UIScripts
{
    public class GameplayHUD : BaseWindow
    {
        [SerializeField]
        private CollectablesComponent _collectables;

        [FormerlySerializedAs("PlayerHPCointainer")]
        [SerializeField]
        private RectTransform _playerHPCointainer;// Контейнер ХП бара игрока

        [FormerlySerializedAs("PlayerHPFill")]
        [SerializeField]
        private RectTransform _playerHPFill;// Шкала ХП игрока

        [FormerlySerializedAs("BossHPCointainer")]
        [SerializeField]
        private RectTransform _bossHPCointainer;// Контейнер ХП бара босса

        [FormerlySerializedAs("BossHPFill")]
        [SerializeField]
        private RectTransform _bossHPFill;// Шкала ХП босса

        [FormerlySerializedAs("PLayer")]
        [SerializeField]
        private ProgressBar _pLayer;

        [FormerlySerializedAs("Enemy")]
        [SerializeField]
        private ProgressBar _enemy;

        [SerializeField]
        private GameObject _baseMove;

        [SerializeField]
        private GameObject _flyMove;

        public CollectablesComponent Collectables => _collectables;

        public ProgressBar PLayer => _pLayer;

        public GameObject BaseMove => _baseMove;

        public GameObject FlyMove => _flyMove;

        public event Action JumpEvent;
        public event Action UpEvent;
        public event Action DownEvent;

        public void OnJumpButtonClick()
        {
            JumpEvent?.Invoke();
        }

        public void OnUpButtonClick()
        {
            UpEvent?.Invoke();
        }

        public void OnDownButtonClick()
        {
            DownEvent?.Invoke();
        }

        public void OnPauseButtonClick()
        {
            SceneStarter.OpenPopup(SceneStarter.Pause, true);
        }
    }
}
