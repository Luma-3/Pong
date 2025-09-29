using System;
using System.Collections;
using Environment;
using PlayerScripts;
using UnityEngine;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        public bool isMainMenu;
        public Ball ballPrefab;
        public Level level;
        public Player[] players;

        public bool ballAcceleration;

        private Ball _actualBall;
        private int _nextBallDirection;
        
        private void Awake()
        {
            if (Instance) Instance = null;
            Instance = this;
        }

        private void OnEnable()
        {
            Goal.OnGoal += OnPlayerGoal;
        }

        private void OnDisable()
        {
            Goal.OnGoal -= OnPlayerGoal;
        }

        private void OnPlayerGoal(int direction)
        {
            _nextBallDirection = direction;
            StartNewRound();
        }

        private void Start()
        {
            _nextBallDirection = -1;
            if (!isMainMenu)
                SetDifficulty();
            StartNewRound();
        }

        private void StartNewRound()
        {
            CreateBall();
            Invoke(nameof(LaunchBall), 2f);
            ResetRacketsPosition();
        }

        private void CreateBall()
        {
            if (_actualBall)
            {
                Destroy(_actualBall.gameObject);
            }
            _actualBall = Instantiate(ballPrefab, level.ballSpawn.position, Quaternion.identity);
        }

        private void LaunchBall()
        {
            _actualBall.LaunchBall(_nextBallDirection);
        }

        public Ball GetBall()
        {
            return _actualBall;
        }

        private void ResetRacketsPosition()
        {
            foreach (var t in players)
            {
                t.GetRacket().ResetPosition();
            }
        }

        private void SetDifficulty()
        {
            players[1].input = GameManager.Instance.actualDifficulty;
            ballAcceleration = GameManager.Instance.ballAcceleration;
        }
    }
}
