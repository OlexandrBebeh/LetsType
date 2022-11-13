using System.Linq;
using _ROOT.Scripts.GlobalWorld;
using _ROOT.Scripts.Settings;
using UnityEngine;

namespace _ROOT.Scripts.Fight
{
    public class FightWatcher : MonoBehaviour
    {
        [SerializeField] public Character character;

        [SerializeField] public UnitSpawner unitSpawner;

        [SerializeField] public RangeChecker rangeChecker;

        private EnemySettings enemySettings;

        private void Awake()
        {
            enemySettings = Resources.Load<EnemySettings>($"Settings/{nameof(EnemySettings)}");
            StartFight(FightController.Instance.GetEnemyName(), FightController.Instance.GetEnemyLevel());
        }

        public void StartFight(string enemyId, int level)
        {
            var stats = enemySettings.stats.First(e => e.id == enemyId);
            character.Init();
            rangeChecker.Init();
            unitSpawner.Init(stats, level);
            unitSpawner.StartSpawn();
        }
    }
}