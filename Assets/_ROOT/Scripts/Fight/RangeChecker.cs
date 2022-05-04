using System;
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
            if (other.GetComponentInParent<Unit>() is not null)
            {
                other.GetComponentInParent<Unit>().MakeAvailable();
            }
        }
    }
}