using PlayerScripts;
using UnityEngine;

namespace ScriptableObj
{
    public abstract class InputRecoverData : ScriptableObject
    {
        public abstract Vector3 GetInput(Player player);
    }
}
