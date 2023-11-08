using System;
using System.Threading;
using System.Threading.Tasks;
using MyRI.Mechanics.Effects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyRI.Components.Collectables
{
    /// <summary>
    /// View class for interface elements for Buff
    /// </summary>
    public class BuffItem : MonoBehaviour
    {
        /// <summary>
        /// icon Image
        /// </summary>
        [SerializeField]
        private Image _icon;
        
        /// <summary>
        /// TExt Mesh pro field for timer text
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI _time;

        /// <summary>
        /// Cancellation toket for timer awaiter
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }


        public async void SetData(BuffData data)
        {
            _icon.sprite = data.Config.Icon;

            _cancellationTokenSource = new CancellationTokenSource();

            while (DateTime.Now < data.BuffEnd)
            {
                var buffEnd = data.BuffEnd - DateTime.Now;
                _time.text = $"{Mathf.RoundToInt((float) buffEnd.TotalSeconds) + 1}";
                await Task.Delay(buffEnd.Milliseconds % 1000, _cancellationTokenSource.Token);
            }

            Destroy(gameObject);
        }
    }
}
