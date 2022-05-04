using System;
using System.Collections.Generic;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] public int WordsAmount;
        
        [SerializeField] public List<int> WordsLength;

        [SerializeField] public float Speed;
        
        [SerializeField] public float DeltaSpeed;
        
        [SerializeField] public string Name;
        
        [SerializeField] public int Reward;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckForPlayer(other))
            {
                
            }
        }

        private bool CheckForPlayer(Collider2D other)
        {
            if (other.gameObject.GetComponentInParent<Player>())
            {
                return true;
            }

            return false;        
        }
    }
}