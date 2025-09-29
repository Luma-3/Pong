using UnityEngine;

namespace Ui.Menu
{
    public class MainMenu : MonoBehaviour
    {
        
        public ConfirmQuitMenu confirmQuitMenu;
        public LevelMenu levelMenu;
        public OptionOpener optionOpener;
        
        public void PlayButton()
        {
            levelMenu.gameObject.SetActive(true);
        }

        public void OptionsButton()
        {
            optionOpener.OpenQuitOptionsMenu();
        }

        public void QuitButton()
        {
            confirmQuitMenu.gameObject.SetActive(true);
        }

    }
}
