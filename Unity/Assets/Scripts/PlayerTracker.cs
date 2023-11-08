using UnityEngine;

namespace MyRI
{
    
    /// <summary>
    /// component for camera. Track character position
    /// </summary>
    public class PlayerTracker : MonoBehaviour
    {
        public Transform player;

        private Vector3 _prevPosition;

        private void LateUpdate()
        {
            if (player == null)
                return;
            var camTrans = transform;
            var position = camTrans.position;
            var playerPosition = player.position;
            var prevPosition = playerPosition - _prevPosition;
            prevPosition.y = 0;
            position += prevPosition;
            camTrans.position = position;
            _prevPosition = playerPosition;
        }
    }
}
