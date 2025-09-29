using Manager.Data;
using ScriptableObj;
using Ui.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public OptionManager optionManager;

        public InputRecoverData actualDifficulty;
        public InputRecoverData[] difficulties;

        public bool ballAcceleration;
        
        public AudioSource audioSource;

        private void Awake()
        {
            if (Instance) Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (!DataSaver.JsonChecker("Option"))
            {
                optionManager.SetDefault();
            }
            else
            {
                optionManager.LoadOptionFile();
            }
        }
        
        private void OnEnable()
        {
            LevelMenu.OnPlay += StartGame;
        }
        
        private void OnDisable()
        {
            LevelMenu.OnPlay -= StartGame;
        }
        
        private void StartGame(int difficultyID, bool acceleration)
        {
            SceneLoader(1);
            SetDifficulty(difficultyID, acceleration);
            CursorStat(false, CursorLockMode.Locked);

        }
        private void SetDifficulty(int id, bool acceleration)
        {
            ballAcceleration = acceleration;
            for (var i = 0; i < difficulties.Length; i++)
            {
                if (i == id)
                {
                    actualDifficulty = difficulties[i];
                }
            }
        }

        public void PlaySound(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        
        public static void SceneLoader(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }

        public static void CursorStat(bool visible, CursorLockMode lockMode)
        {
            Cursor.visible = visible;
            Cursor.lockState = lockMode;
        }
        
    }
}
