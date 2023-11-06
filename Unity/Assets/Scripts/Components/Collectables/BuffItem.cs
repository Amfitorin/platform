using System;
using System.Threading;
using System.Threading.Tasks;
using MyRI.Mechanics;
using MyRI.Mechanics.Effects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyRI.Components.Collectables
{
    public class BuffItem : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TextMeshProUGUI _time;

        private CancellationTokenSource _cancellationTokenSource;


        public async void SetData(BuffData data)
        {
            _icon.sprite = data.Config.Icon;

            _cancellationTokenSource = new CancellationTokenSource();

            while (DateTime.Now < data.BuffEnd)
            {
                var buffEnd = data.BuffEnd - DateTime.Now;
                _time.text = $"{Mathf.RoundToInt((float)buffEnd.TotalSeconds) + 1}";
                await Task.Delay(buffEnd.Milliseconds % 1000, _cancellationTokenSource.Token);
            }
            
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
