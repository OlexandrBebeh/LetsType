using UnityEngine;

namespace _ROOT.Scripts.Game
{
    public class AppStarter : MonoBehaviour
    {
        [SerializeField] private SceneController sceneController;

        private void Awake()
        {
            // process Saves before game start
            sceneController.LoadMenu();
        }
    }
}