using MyRI.Components.Character;
using UnityEngine;

namespace MyRI
{
    /// <summary>
    /// part of level map. Spawned dynamicaly
    /// </summary>
    public class Tilemap : MonoBehaviour
    {
        public Transform PlayerSpawnPoint;
        public int index;
        public MapSpawner spawner;
        public UnityEngine.Tilemaps.Tilemap tile;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponentInParent<CharacterViewComponent>() == null)
                return;
            spawner.ChangeMap(this);
        }
    }
}
