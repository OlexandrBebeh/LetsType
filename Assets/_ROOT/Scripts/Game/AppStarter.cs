using _ROOT.Scripts.Saves;
using UnityEngine;

namespace _ROOT.Scripts.Game
{
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