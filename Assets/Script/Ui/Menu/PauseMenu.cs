using System;
using Manager;
using UnityEngine;

namespace Ui.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        public ConfirmQuitMenu confirmQuitMenu;
        public OptionOpener optionOpener;

        public Hud hud;
    
        public void ResumeButton()
        {
            hud.OpenQuitPauseMenu();
        }

        public void OptionsButton()
        {
            optionOpener.OpenQuitOptionsMenu();
        }

        public void QuitToTitleButton()
        {
            Time.timeScale = 1f;
            GameManager.SceneLoader(0);
            GameManager.CursorStat(true, CursorLockMode.None);
        }

        public void QuitToDesktopButton()
        {
            confirmQuitMenu.gameObject.SetActive(true);
        }
        
    }
}
