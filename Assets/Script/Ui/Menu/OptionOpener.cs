using UnityEngine;

namespace Ui.Menu
{
    public class OptionOpener : MonoBehaviour
    {
        public OptionsMenu optionsMenu;
        
        public void OpenQuitOptionsMenu()
        {
            var optionsMenuObj = optionsMenu.gameObject;
            optionsMenuObj.SetActive(!optionsMenuObj.activeSelf);
        }
    }
}