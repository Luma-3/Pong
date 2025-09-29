using Manager.Data;
using UnityEngine;
using Resolution = Ui.Menu.Resolution;

namespace Manager
{
    public class OptionManager : MonoBehaviour
    {
        public OptionsData actualOption;

        public void SetDefault()
        {
            actualOption = new OptionsData
            {
                volume = 100,
                resolutionID = 0,
                widthResolution = 1920,
                heightResolution = 1080,
                fullscreen = true
            };
            DataSaver.JsonSaver(actualOption,"Option",false);
            ApplyOptions();
        }

        public void ChangeOption(float vol, Resolution resolution, bool fullscreen)
        {
            actualOption = new OptionsData
            {
                volume = vol,
                resolutionID = resolution.id,
                widthResolution = resolution.width,
                heightResolution = resolution.height,
                fullscreen = fullscreen
            };
            
            DataSaver.JsonSaver(actualOption,"Option",false);
            ApplyOptions();
        }

        public void LoadOptionFile()
        {
            actualOption = DataSaver.JsonLoader<OptionsData>("Option", false);
        }

        private void ApplyOptions()
        {
            Screen.SetResolution(actualOption.widthResolution, actualOption.heightResolution, actualOption.fullscreen);
            GameManager.Instance.audioSource.volume = actualOption.volume;
            
        }
    }
    
    [System.Serializable]
    public class OptionsData
    {
        public float volume;
        public int resolutionID;
        public int widthResolution;
        public int heightResolution;
        public bool fullscreen;
    }
}