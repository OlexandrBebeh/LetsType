﻿namespace _ROOT.Scripts.Settings
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = nameof(EnemySettings), menuName = "LetsType/EnemySettings")]
    public class EnemySettings : ScriptableObject
    {
        public List<EnemyStats> stats;
    }

    [Serializable]
    public class EnemyStats
    {
        public string id;

        public int wordsAmount;

        public List<int> wordsLength;

        public float speed;

        public float deltaSpeed;

        public float restoreChance = 0;
        
        public float allAvailableChance = 0;
        
        public int mistakeFactor = 2;
        
        public float speedPerLevel = 0;

        public int wordsAmountPerLevel = 0;

    }
}