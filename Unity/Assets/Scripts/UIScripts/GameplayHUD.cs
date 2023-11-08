using System;
using MyRI.Components;
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

        [SerializeField]
        private ButtonController _jumpButton;

        [SerializeField]
        private ButtonController _flyUp;
        
        [SerializeField]
        private ButtonController _flyDown;

        public CollectablesComponent Collectables => _collectables;

        public ProgressBar PLayer => _pLayer;

        public ButtonController JumpButton => _jumpButton;

        public ButtonController FlyUp => _flyUp;
        
        public ButtonController FlyDown => _flyDown;

        public GameObject BaseMove => _baseMove;

        public GameObject FlyMove => _flyMove;

        public void OnPauseButtonClick()
        {
            SceneStarter.OpenPopup(SceneStarter.Pause, true);
        }
    }
}
