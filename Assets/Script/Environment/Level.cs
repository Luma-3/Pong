using UnityEngine;

namespace Environment
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D levelCollider;

        public Transform ballSpawn;
        
        public Bounds GetBounds()
        {
            return levelCollider.bounds;
        }
    }
}