using System;
using _ROOT.Scripts.Game;
using Unity.VisualScripting;
using UnityEngine;

namespace _ROOT.Scripts.Fight
{
    public class RangeChecker : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            ChangeState(other);
        }

        private void ChangeState(Collider2D other)
        {
            var unit = other.GetComponentInParent<Unit>();
            if (unit)
            {
                unit.MakeAvailable();
            }
        }

        public void Init()
        {
            var parent = GetComponentInParent<Transform>();
            var range = PlayerProvider.Instance.Player.AttackRange;
            parent.localScale.Set(range,range,0);
        }
    }
}