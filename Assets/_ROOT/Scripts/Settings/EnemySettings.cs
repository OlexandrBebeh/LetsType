using System;
using System.Collections.Generic;
using UnityEngine;

namespace _ROOT.Scripts.Settings
{
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
    }
}