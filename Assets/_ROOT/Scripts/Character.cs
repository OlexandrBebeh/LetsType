using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _ROOT.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private int hearts;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            TakeAHit();
        }

        private void TakeAHit()
        {
            hearts--;
            if (hearts < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}