namespace _ROOT.Scripts.GlobalWorld.EnemySpawner
{
    using Game;
    using GlobalWorld;
    using UnityEngine;
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