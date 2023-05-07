namespace _ROOT.Scripts.Fight
{
    using Saves.Player;
    using UnityEngine;
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
            var range = PlayerSavable.Instance.Range;
            transform.localScale = Vector3.one * range;
        }
    }
}