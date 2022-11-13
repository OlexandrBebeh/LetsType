using _ROOT.Scripts.Saves.Level;
using UnityEngine;
using System;
using System.Collections.Generic;
using Random = System.Random;


namespace _ROOT.Scripts.GlobalWorld.EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        private Random rand;

        [SerializeField] public int enemyCount = 1;
        
        [SerializeField] public int deltaEnemyCount = 0;

        [SerializeField] public List<GameObject> unitsForSpawn;

        [SerializeField] public Vector3 spawnFrom;
        
        [SerializeField] public Vector3 spawnTo;

        private void Awake()
        {
            rand = new Random(LevelSavable.Instance.level_seed);
        }

        public void SpawnEnemies()
        {
            var enemyToSpawn = enemyCount + rand.Next(0, deltaEnemyCount);

            while (enemyToSpawn > 0)
            {
                var position = GetRandomVector3();
                
                var unit = Instantiate(unitsForSpawn[rand.Next(0,unitsForSpawn.Count)], position, Quaternion.identity, transform);
                
                enemyToSpawn--;
            }
        }

        private Vector3 GetRandomVector3()
        {
            var randomDirection = Vector3.zero;
            randomDirection.y += rand.Next((int)(spawnFrom.y * 100), (int)(spawnTo.y * 100)) / 100f;
            randomDirection.x += rand.Next((int)(spawnFrom.x * 100), (int)(spawnTo.x * 100)) / 100f;
            return randomDirection;
        }
    }
}