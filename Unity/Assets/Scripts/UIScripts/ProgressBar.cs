using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MyRI.UIScripts
{
    public class ProgressBar : MonoBehaviour
    {
        public RectTransform PlayerHPCointainer;// Контейнер ХП бара игрока
        public RectTransform PlayerHPFill;
        public Image FillImage;

        public Color startColor;
        public Color HitColor;
        private float _current;
        private float _maxValue;

        private float _maxWidth;

        private void Awake()
        {
            _maxWidth = PlayerHPFill.rect.width;
        }

        private void OnEnable()
        {
            var rectWidth = PlayerHPFill.rect;
            rectWidth.width = _maxWidth;
            PlayerHPFill.sizeDelta = new Vector2(rectWidth.width, rectWidth.height);
            FillImage.color = startColor;
        }


        public void SetMax(float max)
        {
            _maxValue = max;
            _current = max;
        }

        public void ApplyDamage(float damage)
        {
            var current = new Vector2(Mathf.Clamp01(_current / _maxValue) * _maxWidth, PlayerHPFill.rect.height);
            var total = new Vector2(Mathf.Clamp01((_current - damage) / _maxValue) * _maxWidth,
            PlayerHPFill.rect.height);
            DOTween.To(() => current, x => PlayerHPFill.sizeDelta = x, total, 0.25f);
            DOTween.To(() => _current, x => _current = x, _current - damage, 0.25f);
        }
    }
}
