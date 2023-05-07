namespace _ROOT.Scripts.Game
{
    using Saves;
    using UnityEngine;
    public class AppStarter : MonoBehaviour
    {
        private void Awake()
        {
            PrepareSaves();
            GameController.Instance.LoadMenu();
        }

        private void PrepareSaves()
        {
            SaveController.Instance.PrepareSave();
        }
    }
}