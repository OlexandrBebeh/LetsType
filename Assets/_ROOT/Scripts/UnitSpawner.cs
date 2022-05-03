using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace _ROOT.Scripts
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnTimeLetter;

        [SerializeField] private float spawnTimeWord;

        [SerializeField] private Unit unitPrefab;

        [SerializeField] private Camera camera;
        
        [SerializeField] public InputProvider inputProvider;
        
        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            var waitWord = new WaitForSeconds(spawnTimeWord);
            var waitLetter = new WaitForSeconds(spawnTimeLetter);

            while (true)
            {
                var word = GetWord();
                var position = GetRandomPosition();

                foreach (var c in word)
                {
                    yield return waitLetter;
                    var unit = Instantiate(unitPrefab, position, Quaternion.identity, transform);
                    unit.Init(c, inputProvider);
                }
                yield return waitWord;
            }
        }

        private string GetWord()
        {
            return "kpi";
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