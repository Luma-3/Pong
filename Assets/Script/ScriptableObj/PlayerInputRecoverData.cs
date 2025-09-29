using PlayerScripts;
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu]
    public class PlayerInputRecoverData : InputRecoverData
    {
        public KeyCode shortcutUp;
        public KeyCode shortcutDown;
        
        public override Vector3 GetInput(Player player)
        {
            var direction = Vector3.zero;
            
            if (Input.GetKey(shortcutUp))
                direction = Vector3.up;
            
            if (Input.GetKey(shortcutDown))
                direction = Vector3.down;
            
            return direction;
        }
    }
}
