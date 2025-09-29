using System;
using Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float launchForce; 
    
        [SerializeField] private Rigidbody2D rb;

        [SerializeField] private AudioClip racketBoundClip;
        [SerializeField] private AudioClip wallBounceClip;

        public bool acceleration;

        private void Awake()
        {
            acceleration = LevelManager.Instance.ballAcceleration;
        }

        public void LaunchBall(int direction)
        {
            var rngDir = new Vector2(direction, Random.Range(0.8f, -0.8f));
            rb.velocity = rngDir * launchForce;
        }

        public void DestroyBall()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Vector2 direction;
            
            var velocity = rb.velocity;
            var magnitude = velocity.magnitude;
            
            if (other.gameObject.CompareTag("Player"))
            {
                direction = transform.position - other.transform.position;
                
                if(acceleration)
                    magnitude = AccelerationBall(magnitude);
                
                GameManager.Instance.PlaySound(racketBoundClip);
            }
            else
            {
                direction = velocity;
                GameManager.Instance.PlaySound(wallBounceClip);
            }
            var newDirection = direction.normalized * magnitude;
            rb.velocity = newDirection;
        }

        private float AccelerationBall(float magnitude)
        {
            return magnitude + 0.1f;
        }
    }
}
