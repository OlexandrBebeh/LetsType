using System.Collections;
using System.Collections.Generic;
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

        [SerializeField] private int wordsForSpawn;

        [SerializeField] private Unit unitPrefab;

        [SerializeField] public InputProvider inputProvider;

        [SerializeField] public Character character;

        [SerializeField] public int letterSpawnDelim;

        private WordsGenerator wordsGenerator;

        private Camera camera;

        private List<int> wordsLength;

        private int wordsLeft;

        private bool finishSpawning;

        private List<Unit> spawnedUnits = new List<Unit>();

        private IEnumerator SpawnRoutine()
        {
            var waitLetter = new WaitForSeconds(spawnTimeLetter);
            wordsLeft = wordsForSpawn;

            while (true)
            {
                var word = GetWord();
                wordsLeft--;
                var position = GetRandomPosition();

                foreach (var c in word)
                {
                    yield return waitLetter;
                    var unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);
                    unit.Init(c, inputProvider, character.transform.position);
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
                ;
            }
        }

        private void OnUnitDeath(Unit unit)
        {
            unit.OnDeath -= OnUnitDeath;
            spawnedUnits.Remove(unit);
            
            if (IsFinishSpawning())
            {
                GameEvents.StartFightEndEvent(FightResults.Win);
            }
        }

        private string GetWord()
        {
            return wordsGenerator.GetWord(wordsLength[(int) (Random.value * wordsLength.Count) % wordsLength.Count]);
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
            camera = Camera.main;
            wordsGenerator = new WordsGenerator();
            wordsForSpawn = stats.wordsAmount;
            spawnTimeLetter = letterSpawnDelim / stats.speed;
            wordsLength = stats.wordsLength;
            finishSpawning = false;
        }

        public void StartSpawn()
        {
            StartCoroutine(SpawnRoutine());        
        }
    }
}