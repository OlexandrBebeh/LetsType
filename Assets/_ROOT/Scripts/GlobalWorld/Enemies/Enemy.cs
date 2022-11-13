using System;
using System.Collections.Generic;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] public string Name;
        
        [SerializeField] public int level = 1;

        [SerializeField] public int Reward;

        public virtual void DestroySelf()
        {
            Destroy(gameObject); 
        }
    }
}