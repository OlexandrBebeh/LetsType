using _ROOT.Scripts.Saves;
using UnityEngine;

namespace _ROOT.Scripts.Game
{
    public class AppStarter : MonoBehaviour
    {
        [SerializeField] private SceneController sceneController;

        private void Awake()
        {
            PrepareSaves();
            sceneController.LoadMenu();
        }

        private void PrepareSaves()
        {
            SaveController.Instance.PrepareSave();
        }
    }
}