using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld.EnemySpawner
{
    public class LevelStarterWithGenerator : LevelStarter   
    {
        [SerializeField] public EnemySpawner Spawner;

        private void Awake()
        {
            CameraController.Instance.FocusWorldCamera(PlayerProvider.Instance.Player.transform);
            CameraController.Instance.EnableWorldCamera();
            Spawner.SpawnEnemies();
        }
    }
}