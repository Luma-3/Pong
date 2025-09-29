using System;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu
{
    public class OptionsMenu : MonoBehaviour
    {
        public OptionOpener optionOpener;

        public Slider volume;
        public TMP_Dropdown resolution;
        public Toggle fullscreen;
        
        [SerializeField] private Resolution[] resolutions;

        private void OnEnable()
        {
            LoadUiOption();
        }

        private void LoadUiOption()
        {
            var actualOption = GameManager.Instance.optionManager.actualOption;

            volume.value = actualOption.volume;
            fullscreen.isOn = actualOption.fullscreen;
            resolution.value = actualOption.resolutionID;
        }

        public void ApplyAndBackButton()
        {
            ApplyOptions();
            optionOpener.OpenQuitOptionsMenu();
        }

        private void ApplyOptions()
        {
            FormatResolution(resolution.value);
            GameManager.Instance.optionManager.ChangeOption
                (
                    volume.value,
                    FormatResolution(resolution.value),
                    fullscreen.isOn
                    
                );
        }

        private Resolution FormatResolution(int resolutionValue)
        {
            var res = new Resolution();
            
            foreach (var t in resolutions)
            {
                if (resolutionValue == t.id)
                {
                    res = new Resolution
                    {
                        id = t.id,
                        width = t.width,
                        height = t.height
                    };
                }
            }

            return res;
        }
    }

    [Serializable]
    public struct Resolution
    {
        public int id;
        public int width;
        public int height;
    }
}
