using System;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld;
using Unity.VisualScripting;
using UnityEngine;

namespace _ROOT.Scripts.Fight
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
            if (hearts == 0)
            {
                GameEvents.StartFightEndEvent(FightResults.Lose);
                Destroy(gameObject);
            }
        }
        
        private void TryToDestroy(Collider2D other)
        {
            var unit = other.GetComponentInParent<Unit>();
            if (unit is not null)
            {
                unit.Die();
                TakeAHit();
            }
        }
    }
}