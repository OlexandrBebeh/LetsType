namespace _ROOT.Scripts.GlobalWorld.EnemySpawner
{
    using Saves.Level;
    using UnityEngine;
    using System;
    using System.Collections.Generic;
    using Random = System.Random;
    public class EnemySpawner : MonoBehaviour
    {
        private Random rand;

        [SerializeField] public int enemyCount = 1;
        
        [SerializeField] public int deltaEnemyCount = 0;

        [SerializeField] public List<GameObject> unitsForSpawn;

        [SerializeField] public Vector3 spawnFrom;
        
        [SerializeField] public Vector3 spawnTo;

        [SerializeField] public GameObject enemyList;

        private const int MAX_ATTEMPTS = 100;
        
        private void Awake()
        {
            rand = new Random(LevelSavable.Instance.level_seed);
        }

        public void SpawnEnemies()
        {
            var enemyToSpawn = enemyCount + rand.Next(0, deltaEnemyCount);
            int attempts = 0;
            while (enemyToSpawn > 0)
            {
                attempts++;
                if (attempts >= MAX_ATTEMPTS)
                {
                    break;
                }
                
                var position = GetRandomVector3();
                
                var unit = Instantiate(unitsForSpawn[rand.Next(0,unitsForSpawn.Count)], position, Quaternion.identity, transform);
                
                bool noCollisions = CheckForCollision(unit);

                if (noCollisions)
                {
                    Destroy(unit.gameObject);
                }
                else
                {
                    enemyToSpawn--;
                    unit.transform.parent = enemyList.transform;
                }
            }
        }

        private Vector3 GetRandomVector3()
        {
            var randomDirection = Vector3.zero;
            randomDirection.y += rand.Next((int)(spawnFrom.y * 100), (int)(spawnTo.y * 100)) / 100f;
            randomDirection.x += rand.Next((int)(spawnFrom.x * 100), (int)(spawnTo.x * 100)) / 100f;
            return randomDirection;
        }

        private bool CheckForCollision(GameObject unit)
        {
            var unitCollider = unit.GetComponent<Collider2D>();

            if (!unitCollider)
            {
                return true;
            }
            
            foreach (var spawned in FindObjectsOfType<GameObject>())
            {

                var spawnedCollider = spawned.GetComponent<Collider2D>();

                if (spawnedCollider)
                {
                    if (spawnedCollider.bounds.Intersects(unitCollider.bounds))
                    {
                        if (ReferenceEquals(spawnedCollider, unitCollider))
                        {
                            continue;
                        }
                        return true;
                    }
                }
            }

            return false;
        }
    }
}