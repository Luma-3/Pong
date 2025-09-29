using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Ui.Menu
{
    public class LevelMenu : MonoBehaviour
    {
        public TMP_Dropdown difficultyDropdown;
        public Toggle ballAccelerationToggle;

        public delegate void OnPlayDelegate(int difficulty, bool ballAcceleration);
        public static event OnPlayDelegate OnPlay;
        
        public void PlayButton()
        {
            Invoke(nameof(Play),0.5f);
        }

        public void ReturnButton()
        {
            gameObject.SetActive(false);
        }

        public void Play()
        {
            OnPlay.Invoke(difficultyDropdown.value, ballAccelerationToggle.isOn);
        }
    }
}