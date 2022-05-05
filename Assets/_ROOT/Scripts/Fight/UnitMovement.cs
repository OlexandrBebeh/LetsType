using UnityEngine;

namespace _ROOT.Scripts.Fight
{
    public class UnitMovement : MonoBehaviour
    {
        [SerializeField] private Unit unit;
        
        private void Update()
        {
            var position = transform.position;
            var target = unit.GetTarget();
            var direction = (target - position).normalized;
            var translation = direction * unit.speed * Time.deltaTime;
            transform.position = position + translation;
        }
    }
}