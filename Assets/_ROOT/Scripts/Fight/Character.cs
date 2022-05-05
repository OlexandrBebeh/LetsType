using System;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld;
using Unity.VisualScripting;
using UnityEngine;

namespace _ROOT.Scripts.Fight
{
    public class Character : MonoBehaviour
    {
        
        [SerializeField] public int MaxHearts;
        
        [SerializeField] public int hearts;
        private void OnTriggerEnter2D(Collider2D other)
        {
            TryToDestroy(other);
        }

        public void Init()
        {
            hearts = MaxHearts = PlayerProvider.Instance.Player.Hearts;
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
        
        public void Heal(int heal)
        {
            hearts += heal;

            if (hearts > MaxHearts)
            {
                hearts = MaxHearts;
            }
        }
    }
}