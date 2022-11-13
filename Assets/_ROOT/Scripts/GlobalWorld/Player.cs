using System;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld.Enemies;
using _ROOT.Scripts.Saves;
using _ROOT.Scripts.Saves.Player;
using _ROOT.Scripts.Tools;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public float Speed;

        [SerializeField] public float ShiftSpeed;

        private bool IsSprint;

        public bool CanMove;

        private Vector2 desireMovement;

        private void Awake()
        {
            CanMove = true;
        }

        private void Update()
        {
            IsSprint = Input.GetKey(KeyCode.LeftShift);
            var horizontalMovement = Input.GetAxis("Horizontal");
            var verticalMovement = Input.GetAxis("Vertical");
            desireMovement = new Vector2(horizontalMovement, verticalMovement);
        }

        private void FixedUpdate()
        {
            if (CanMove)
            {
                Move();
            }
        }

        private void Move()
        {
            Vector3 direction = desireMovement.normalized;
            var speed = Speed;
            if (IsSprint)
            {
                speed *= ShiftSpeed;
            }

            transform.position += direction * speed * Time.fixedDeltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.gameObject.GetComponentInParent<Enemy>();
            if (CheckForFight(enemy))
            {
                DisableMove();
                GameController.Instance.StartFight(enemy);
            }
        }

        private bool CheckForFight(Enemy enemy)
        {
            return enemy;
        }

        public void DisableMove()
        {
            CanMove = false;
        }

        public void EnableMove()
        {
            CanMove = true;
        }
        
        [EditorButton]
        public void AddGold()
        {
            PlayerSavable.Instance.Gold += 100;
        }

        public void SubscribeForMove(bool isDialogEnd)
        {
            CanMove = !isDialogEnd;
        }
    }
}