using PlayerScripts;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class ScoreDisplay : MonoBehaviour
    {
        public Player owner;
        private TextMeshProUGUI _textScore;

        private void Awake()
        {
            _textScore = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            Player.OnScoreChange += ChangeScore;
        }

        private void OnDisable()
        {
            Player.OnScoreChange -= ChangeScore;
        }

        private void ChangeScore(Player player, int score)
        {
            if (player == owner)
            {
                _textScore.text = $"{score}";
            }
        }
    }
}
