using UnityEngine;

namespace _ROOT.Scripts
{
    public class UnitMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            var position = transform.position;
            var target = Vector3.zero;
            var direction = (target - position).normalized;
            var translation = direction * speed * Time.deltaTime;
            transform.position = position + translation;
        }
    }
}