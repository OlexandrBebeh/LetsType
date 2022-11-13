﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _ROOT.Scripts.Dictionary;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld;
using _ROOT.Scripts.Settings;
using UnityEngine;
using Random = UnityEngine.Random;

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

        private UnitModificator modificator;

        private EnemyStats enemyStats;
        
        private WordsGenerator wordsGenerator;

        private Camera camera;
        
        private int wordsLeft;

        private bool finishSpawning;

        private Dictionary<string, List<Unit>> spawnedUnits;

        private int charactersLeft;
        
        private IEnumerator SpawnRoutine()
        {
            var waitLetter = new WaitForSeconds(spawnTimeLetter);
            wordsLeft = enemyStats.wordsAmount;
            inputProvider.OnInput += OnInput;
            while (true)
            {
                var word = GetWord();
                spawnedUnits.Add(word, new List<Unit>());
                wordsLeft--;
                var position = GetRandomPosition();

                foreach (var c in word)
                {
                    yield return waitLetter;
                    var unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);
                    unit.Init(c, character.transform.position, enemyStats.speed);
                    modificator.ModifyUnit(unit);
                    spawnedUnits[unit.word = word].Add(unit);
                    unit.OnDeath += OnUnitDeath;
                }

                if (wordsLeft == 0)
                {
                    finishSpawning = true;
                    break;
                }

                spawnTimeWord = word.Length * spawnTimeLetter;
                yield return new WaitForSeconds(spawnTimeWord);
            }
        }

        private void OnUnitDeath(Unit unit)
        {
            unit.OnDeath -= OnUnitDeath;
            spawnedUnits[unit.word].Remove(unit);
            if (unit.makeAllAvailable)
            {
                MakeAllAvailable();
            }

            if (unit.IsRestoreUnit)
            {
                character.Heal();
            }
            if (spawnedUnits[unit.word].Count == 0)
            {
                spawnedUnits.Remove(unit.word);
            }
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
            var randomDirection = Vector3.zero;
            randomDirection.y += size * Random.Range(0.7f, 1f);
            randomDirection.x += size * Random.Range(-1f, 1f);
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
            modificator = new ();
            spawnedUnits = new Dictionary<string, List<Unit>>();
            camera = Camera.main;
            wordsGenerator = new WordsGenerator();
            spawnTimeLetter = letterSpawnDelim / stats.speed;
            enemyStats = stats;
            finishSpawning = false;
            modificator.Init(stats);
            charactersLeft = stats.wordsAmount * stats.wordsLength.Max() / stats.mistakeFactor;
        }

        public void StartSpawn()
        {
            StartCoroutine(SpawnRoutine());        
        }
        
        private void OnInput(char inputChar)
        {
            if (spawnedUnits.Count != 0
                && Time.timeScale != 0f)
            {
                bool used = true;
                foreach (var lst in spawnedUnits)
                {
                    if (lst.Value.Count != 0 && lst.Value.First().isActive && lst.Value.First().TargetChar == inputChar)
                    {
                        lst.Value.First().Die();
                        used = false;
                        break;
                    }
                }

                if (used)
                {
                    if (charactersLeft == 0)
                    {
                        character.TakeAHit();
                    }
                    else
                    {
                        charactersLeft--;
                    }
                }
            }
        }

        private void MakeAllAvailable()
        {
            foreach (var lst in spawnedUnits)
            {
                if (lst.Value.Count != 0)
                {
                    foreach (var unit in lst.Value)
                    {
                        unit.MakeAvailable();
                    }
                }
            }
        }

        public int GetCharactersLeft()
        {
            return charactersLeft;
        }

        private void OnDestroy()
        {
            if (!IsFinishSpawning())
            {
                GameEvents.StartFightEndEvent(FightResults.Lose);
            }
        }
    }
}