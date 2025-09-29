using ScriptableObj;
using UnityEngine;

namespace PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public InputRecoverData input;
        [SerializeField] private Racket racket;
        
        private int _score;
        private int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnScoreChange?.Invoke(this, _score);
            }
        }

        public delegate void OnScoreChangeDelegate(Player player, int score);
        public static event OnScoreChangeDelegate OnScoreChange;

        private void FixedUpdate()
        {
            var direction = input.GetInput(this);
            racket.PerformMovement(direction);
        }

        public void IncrementScore()
        {
            Score++;
        }

        public Racket GetRacket()
        {
            return racket;
        }
    }
}