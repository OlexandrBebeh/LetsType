using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _ROOT.Scripts
{
    public class Character : MonoBehaviour
    {
        
        [SerializeField] public int MaxHearts = 5;
        
        [SerializeField] public int hearts;

        [SerializeField] public int charsToRestoreHeart = 10;
        private void Start()
        {
            hearts = MaxHearts;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TryToDestroy(other);
        }

        private void TakeAHit()
        {
            hearts--;
            if (hearts < 0)
            {
                Destroy(gameObject);
            }
        }
        
        private void TryToDestroy(Collider2D other)
        {
            if (other.GetComponentInParent<Unit>() is not null)
            {
                Destroy(other.gameObject);
                TakeAHit();
            }
        }
    }
}