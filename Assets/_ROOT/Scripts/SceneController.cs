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
            UnloadScene(str);
        }

        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        
        private void UnloadScene(string sceneName)
        {
            SceneManager.UnloadScene(sceneName);
        }
    }
}