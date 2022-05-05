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
            LoadSaves();
            sceneController.LoadMenu();
        }

        private void PrepareSaves()
        {
            SaveController.Instance.PrepareSave();
        }

        private void LoadSaves()
        {
            SaveController.Instance.LoadSave();
        }
    }
}