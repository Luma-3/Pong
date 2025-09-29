using System;
using Manager;
using UnityEngine;
using PlayerScripts;

namespace Environment
{
    public class Goal : MonoBehaviour
    {
        public Player opponent;
        [Range(-1,1)] public int positionOnTerrain;

        [SerializeField] private AudioClip goalClip;
        
        public static event Action<int> OnGoal;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var ball = other.gameObject.GetComponent<Ball>();
            if (ball != null)
            {
                ball.DestroyBall();
                opponent.IncrementScore();
                OnGoal?.Invoke(positionOnTerrain);
                GameManager.Instance.PlaySound(goalClip);
            }
        }
    }
}