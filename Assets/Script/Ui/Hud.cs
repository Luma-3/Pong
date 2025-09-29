using Manager;
using Ui.Menu;
using UnityEngine;

namespace Ui
{
    public class Hud : MonoBehaviour
    {
        public PauseMenu pauseMenu;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenQuitPauseMenu();
            }
        }

        public void OpenQuitPauseMenu()
        {
            var pauseMenuObj = pauseMenu.gameObject;
            pauseMenuObj.SetActive(!pauseMenuObj.activeSelf);

            Time.timeScale = pauseMenuObj.activeSelf ? 0f : 1f;
            GameManager.CursorStat(pauseMenuObj.activeSelf, pauseMenuObj.activeSelf ? CursorLockMode.None : CursorLockMode.Locked);
        }
    }
}