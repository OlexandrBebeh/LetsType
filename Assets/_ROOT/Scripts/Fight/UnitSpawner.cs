﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _ROOT.Scripts.Dictionary;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld;
using _ROOT.Scripts.GlobalWorld.Enemies;
using _ROOT.Scripts.Settings;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _ROOT.Scripts.Fight
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnTimeLetter;

        [SerializeField] private float spawnTimeWord;
        
        [SerializeField] public int letterSpawnDelim;

        [SerializeField] public float restoreUnit;
        
        [SerializeField] public float availableUnit;

        [SerializeField] private Unit unitPrefab;

        [SerializeField] public InputProvider inputProvider;

        [SerializeField] public Character character;

        private EnemyStats enemyStats;
        
        private WordsGenerator wordsGenerator;

        private Camera camera;
        
        private int wordsLeft;

        private bool finishSpawning;

        private List<Unit> spawnedUnits;

        private IEnumerator SpawnRoutine()
        {
            var waitLetter = new WaitForSeconds(spawnTimeLetter);
            wordsLeft = enemyStats.wordsAmount;
            inputProvider.OnInput += OnInput;
            while (true)
            {
                var word = GetWord();
                wordsLeft--;
                var position = GetRandomPosition();

                foreach (var c in word)
                {
                    yield return waitLetter;
                    var unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);
                    unit.Init(c, character.transform.position, enemyStats.speed);
                    spawnedUnits.Add(unit);
                    unit.OnDeath += OnUnitDeath;
                }

                if (wordsLeft == 0)
                {
                    finishSpawning = true;
                    break;
                }

                spawnTimeWord = spawnTimeLetter * word.Length + 1;
                yield return new WaitForSeconds(spawnTimeWord);
            }
        }

        private void OnUnitDeath(Unit unit)
        {
            unit.OnDeath -= OnUnitDeath;
            spawnedUnits.Remove(unit);
            
            if (IsFinishSpawning())
            {
                inputProvider.OnInput -= OnInput;
                GameEvents.StartFightEndEvent(FightResults.Win);
            }
        }

        private string GetWord()
        {
            return wordsGenerator.GetWord(enemyStats.wordsLength[(int) (Random.value * enemyStats.wordsLength.Count) % enemyStats.wordsLength.Count]);
        }

        private Vector3 GetRandomPosition()
        {
            var size = camera.orthographicSize;
            var randomDirection = Random.onUnitSphere;
            randomDirection.z = 0;
            randomDirection *= 1.1f;
            randomDirection.y += size;
            randomDirection += character.transform.position;
            return randomDirection;
        }

        public int GetWordsLeft()
        {
            return wordsLeft;
        }

        public bool IsFinishSpawning()
        {
            return finishSpawning && spawnedUnits.Count == 0;
        }

        public void Init(EnemyStats stats)
        {
            spawnedUnits = new List<Unit>();
            camera = Camera.main;
            wordsGenerator = new WordsGenerator();
            spawnTimeLetter = letterSpawnDelim / stats.speed;
            enemyStats = stats;
            finishSpawning = false;
        }

        public void StartSpawn()
        {
            StartCoroutine(SpawnRoutine());        
        }
        
        private void OnInput(char inputChar)
        {
            if (spawnedUnits.Count != 0 
                && inputChar == spawnedUnits.First().TargetChar 
                && spawnedUnits.First().isActive)
            {
                spawnedUnits.First().Die();
            }
        }

        private void MakeAllAvailable()
        {
            foreach (var unit in spawnedUnits)
            {
                unit.MakeAvailable();
            }
        }
    }
}