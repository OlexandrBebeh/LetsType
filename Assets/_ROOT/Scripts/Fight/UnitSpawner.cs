using Unity.VisualScripting;

namespace _ROOT.Scripts.Fight
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Dictionary;
    using Game;
    using GlobalWorld;
    using Settings;
    using UnityEngine;
    using Random = UnityEngine.Random;
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

        private float calculatedSpeed;
        
        private int calculatedWordsAmount;

        private IEnumerator SpawnRoutine()
        {
            var waitLetter = new WaitForSeconds(spawnTimeLetter);
            wordsLeft = enemyStats.wordsAmount;
            inputProvider.OnInput += OnInput;
            while (true)
            {
                var word = GetWord();
                if (spawnedUnits.ContainsKey(word))
                {
                    yield return new WaitForSeconds(1);
                    continue;
                }
                spawnedUnits.Add(word, new List<Unit>());
                wordsLeft--;
                var position = GetRandomPosition();

                foreach (var c in word)
                {
                    yield return waitLetter;
                    var unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);
                    unit.Init(c, character.transform.position, calculatedSpeed);
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
            if (unit.makeAllAvailable)
            {
                MakeAllAvailable();
            }

            if (unit.IsRestoreUnit)
            {
                character.Heal();
            }
            
            spawnedUnits[unit.word].Remove(unit);

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

        public void Init(EnemyStats stats, int level)
        {
            modificator = new ();
            spawnedUnits = new Dictionary<string, List<Unit>>();
            camera = Camera.main;
            wordsGenerator = new WordsGenerator();
            enemyStats = stats;
            calculatedSpeed = stats.speed + stats.speedPerLevel * level;
            spawnTimeLetter = letterSpawnDelim / calculatedSpeed;
            calculatedWordsAmount = stats.wordsAmount + stats.wordsAmountPerLevel * level;
            finishSpawning = false;
            modificator.Init(stats);
            charactersLeft = stats.mistakeFactor;
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
                    if (lst.Value.Count != 0)
                    {
                        if (lst.Value.First().IsUnityNull())
                        {
                            lst.Value.Remove(lst.Value.First());
                        }
                    
                        if (lst.Value.First().isActive 
                            && lst.Value.First().TargetChar == inputChar)
                        {
                            lst.Value.First().Die();
                            used = false;
                            break;
                        }
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