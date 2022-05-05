using System;
using TMPro;
using UnityEngine;

namespace _ROOT.Scripts.Fight
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;

        [SerializeField] public float speed;

        public bool IsRestoreUnit;
        
        public bool MakeAllAvailable;
        public event Action<Unit> OnDeath;


        public char TargetChar { get; private set; }

        private Vector3 Target;

        public bool isActive;

        public void Init(char targetChar, Vector3 target, float _speed)
        {
            TargetChar = targetChar;
            label.SetText(targetChar.ToString());
            label.faceColor = Color.red;
            Target = target;
            isActive = false;
            speed = _speed;
        }

        public void MakeAvailable()
        {
            isActive = true;
            label.faceColor = Color.blue;
        }


        private void OnInput(char inputChar)
        {
            if (inputChar == TargetChar && isActive)
            {
                Die();
            }
        }

        public void Die()
        {
            OnDeath?.Invoke(this);
            Destroy(gameObject);
        }

        public Vector3 GetTarget()
        {
            return Target;
        }
    }
}