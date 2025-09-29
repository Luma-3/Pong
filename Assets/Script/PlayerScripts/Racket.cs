using Manager;
using UnityEngine;

namespace PlayerScripts
{
    public class Racket : MonoBehaviour
    {
        
        [SerializeField] private float speed;

        private Vector3 _defaultPosition;

        private void Awake()
        {
            _defaultPosition = transform.position;
        }

        public void PerformMovement(Vector3 direction)
        {
            transform.position += direction * (speed * Time.deltaTime);
            
            ClampPosition();
        }

        private void ClampPosition()
        {
            var position = transform.position;
            var levelBounds = LevelManager.Instance.level.GetBounds();
            var max = levelBounds.max.y;
            var min = levelBounds.min.y;
            position.y = Mathf.Clamp(position.y, min, max);
            transform.position = position;
        }

        public void ResetPosition()
        {
            transform.position = _defaultPosition;
        }
    }
}
