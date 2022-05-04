﻿using System;
using System.Linq;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld;
using _ROOT.Scripts.Settings;
using UnityEngine;

namespace _ROOT.Scripts.Fight
{
    public class FightWatcher : MonoBehaviour
    {
        [SerializeField] public Character character;

        [SerializeField] public UnitSpawner unitSpawner;

        private EnemySettings enemySettings;

        private void Awake()
        {
            enemySettings = Resources.Load<EnemySettings>($"Settings/{nameof(EnemySettings)}");
            StartFight(FightController.Instance.GetEnemyName());
        }

        public void StartFight(string enemyId)
        {
            var stats = enemySettings.stats.First(e => e.id == enemyId);
            unitSpawner.Init(stats);
            unitSpawner.StartSpawn();
        }
    }
}