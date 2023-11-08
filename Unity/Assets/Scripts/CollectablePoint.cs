using System;
using System.Linq;
using MyRI.Configs.Collectables;
using UnityEngine;

namespace MyRI
{
    /// <summary>
    /// spawn point for collectables elements. Spawn element with spawn weight and send collect event
    /// </summary>
    public class CollectablePoint : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField]
        private float chance;

        [SerializeField]
        private CollectableRollItem[] _rollItems;

        [SerializeField]
        private SpriteRenderer Renderer;

        [SerializeField]
        private float maxWidth = 3f;

        [SerializeField]
        private Collider2D Collider;

        public CollectableConfig Config { get; private set; }

        private void OnEnable()
        {
            Renderer.enabled = false;
            RollItem();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Config == null)
                return;

            CollectableTaken?.Invoke(this);
            gameObject.SetActive(false);
        }
        public event Action<CollectablePoint> CollectableTaken;

        private void RollItem()
        {
            var random = RandomUtils.Instance.Random;

            var nextDouble = random.NextDouble();
            var rolled = nextDouble <= chance;
            if (rolled)
            {
                var totalWeight = _rollItems.Sum(x => x.weight);
                var next = random.NextDouble();

                var rolls = _rollItems.ToList();
                rolls.Sort((f, s) => -1 * f.weight.CompareTo(s.weight));
                foreach (var rollItem in rolls)
                {
                    var currentWeight = rollItem.weight / totalWeight;
                    if (currentWeight <= next)
                    {
                        next -= currentWeight;
                        continue;
                    }

                    var bounds = rollItem.Config.Icon.bounds;
                    var factor = maxWidth / bounds.size.y;
                    Renderer.transform.localScale = new Vector3(factor, factor, factor);
                    Renderer.sprite = rollItem.Config.Icon;
                    Config = rollItem.Config;
                    Renderer.enabled = true;
                    Collider.enabled = true;
                    return;
                }
            }

            Collider.enabled = false;
        }
    }

    [Serializable]
    public struct CollectableRollItem
    {
        public CollectableConfig Config;
        public float weight;
    }
}
