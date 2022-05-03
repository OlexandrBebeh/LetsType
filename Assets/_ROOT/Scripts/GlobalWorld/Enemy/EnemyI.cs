using System.Collections.Generic;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld.Enemy
{
    public abstract class EnemyI : MonoBehaviour
    {
        [SerializeField] public int WordsAmount;
        
        [SerializeField] public List<int> WordsLength;

        [SerializeField] public float Speed;
        
        [SerializeField] public float DeltaSpeed;
    }
}