using _ROOT.Scripts.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _ROOT.Scripts
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private string menuScene;

        [SerializeField] private string fightScene;

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