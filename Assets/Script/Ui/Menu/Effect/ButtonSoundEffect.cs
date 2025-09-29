using Manager;
using UnityEngine;

namespace Ui.Menu.Effect
{
    public class ButtonSoundEffect : MonoBehaviour
    {
        public AudioClip hoverClip;
        public AudioClip clickClip;
        public AudioClip playClip;
        public AudioClip outClip;
        public AudioClip inClip;

        public void OnHover()
        {
            GameManager.Instance.PlaySound(hoverClip);
        } 
    
        public void OnClick()
        {
            GameManager.Instance.PlaySound(clickClip);
        }
    
        public void OnPlay()
        {
            GameManager.Instance.PlaySound(playClip);
        }
    
        public void OnOut()
        {
            GameManager.Instance.PlaySound(outClip);
        }
        public void OnIn()
        {
            GameManager.Instance.PlaySound(inClip);
        }
    }
}
