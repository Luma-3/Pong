using Manager;
using PlayerScripts;
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu]
    public class AiInputRecoverData : InputRecoverData
    {
        public float threshold;
        
        public override Vector3 GetInput(Player player)
        {
            var direction = Vector3.zero;
            var ballPos = LevelManager.Instance.GetBall().transform.position;
            {
                var racketPos = player.GetRacket().transform.position;
                if (racketPos.y > ballPos.y + threshold)
                {
                    direction = Vector3.down;
                }

                if (racketPos.y < ballPos.y - threshold)
                {
                    direction = Vector3.up;
                }
            }
            return direction;
        }
    }
}
