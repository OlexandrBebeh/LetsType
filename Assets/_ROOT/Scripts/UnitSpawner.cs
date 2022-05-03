using System.Collections;
using _ROOT.Scripts.Dictionary;
using UnityEngine;
using UnityEngine.Serialization;

namespace _ROOT.Scripts
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnTimeLetter;

        [SerializeField] private float spawnTimeWord;

        [SerializeField] private int wordsForSpawn = 100;

        [SerializeField] private Unit unitPrefab;

        [SerializeField] public InputProvider inputProvider;

        private WordsGenerator wordsGenerator;
        private Camera camera;

        private void Start()
        {
            camera = Camera.main;
            wordsGenerator = new WordsGenerator();
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            var waitWord = new WaitForSeconds(spawnTimeWord);
            var waitLetter = new WaitForSeconds(spawnTimeLetter);
            int amountOfWords = wordsForSpawn;
            while (true)
            {
                var word = GetWord();
                amountOfWords--;
                var position = GetRandomPosition();

                foreach (var c in word)
                {
                    yield return waitLetter;
                    var unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);
                    unit.Init(c, inputProvider);
                }

                if (amountOfWords == 0)
                {
                    break;
                }

                yield return waitWord;
            }
        }

        private string GetWord()
        {
            return wordsGenerator.GetWord(5);
        }

        private Vector3 GetRandomPosition()
        {
            var size = camera.orthographicSize;
            var randomDirection = Random.onUnitSphere;
            randomDirection.z = 0;
            return randomDirection * size * 1.1f;
        }
    }
}