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
    }
}