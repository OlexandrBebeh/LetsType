﻿namespace _ROOT.Scripts.Fight
{
    using System;
    using Game;
    using GlobalWorld;
    using Saves.Player;
    using UnityEngine;
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
            hearts = MaxHearts = PlayerSavable.Instance.Hearts;
        }
        public void TakeAHit()
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
                unit.Destroy();
                TakeAHit();
            }
        }
        
        public void Heal(int heal = 1)
        {
            hearts += heal;

            if (hearts > MaxHearts)
            {
                hearts = MaxHearts;
            }
        }
    }
}