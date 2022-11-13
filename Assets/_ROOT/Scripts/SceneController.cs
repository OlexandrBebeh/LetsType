using _ROOT.Scripts.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _ROOT.Scripts
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private string menuScene;

        [SerializeField] private string fightScene;

        [SerializeField] private string levelScene;

        [SerializeField] private int lastSceneWithoutAutoGenerate;

        [SerializeField] private string levelGenerateScene;

        private int currentLevel;
        public void LoadMenu()
        {
            LoadScene(menuScene);
        }
        
        public void UnloadMenu()
        {
            UnloadScene(menuScene);
        }

        public void SwitchToFightScene()
        {
            LoadScene(fightScene);
        }

        public void UnloadFightScene()
        {
            UnloadScene(fightScene);
        }
        
        public void SwitchToLevelScene(int level)
        {
            string str;
            if (level < 10)
            {
                str = levelScene + "0" + level;
            }
            else
            {
                str = levelScene + level;
            }
            if (lastSceneWithoutAutoGenerate <= level)
            {
                str = levelGenerateScene;
            }
            LoadScene(str);
            currentLevel = level;
        }

        public void UnloadLevelScene(int level)
        {
            string str;
            if (level < 10)
            {
                str = levelScene + "0" + level;
            }
            else
            {
                str = levelScene + level;
            }

            if (lastSceneWithoutAutoGenerate <= level)
            {
                str = levelGenerateScene;
            }
            UnloadScene(str);
        }

        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        
        private void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}