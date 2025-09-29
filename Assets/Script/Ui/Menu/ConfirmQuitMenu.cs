using UnityEngine;

namespace Ui.Menu
{
    public class ConfirmQuitMenu : MonoBehaviour
    {
        public void Yes()
        {
            Time.timeScale = 1f;
            Invoke(nameof(Quit), 0.3f);
        }

        public void No()
        {
            gameObject.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
