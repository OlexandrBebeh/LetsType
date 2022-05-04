using System;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld.Enemies;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public int Hearts;
        
        [SerializeField] public int Gold;

        [SerializeField] public float Speed;

        [SerializeField] public float ShiftSpeed;

        private bool IsSprint;
        
        public bool CanMove;

        private void Awake()
        {
            CanMove = true;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                IsSprint = true;
            }
            else
            {
                IsSprint = false;
            }
            
            if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && CanMove)
            {
                Move();
            }
        }

        private void Move()
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal") + transform.up * Input.GetAxis("Vertical");
            var speed = Speed;

            if (IsSprint)
            {
                speed *= ShiftSpeed;
            }
                
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.gameObject.GetComponentInParent<Enemy>();
            if (CheckForFight(enemy))
            {
                PreparePlayerForFight();
                GameController.Instance.StartFight(enemy);
            }
        }

        private bool CheckForFight(Enemy enemy)
        {
            return enemy;
        }

        private void PreparePlayerForFight()
        {
            CanMove = false;
            PlayerParameters.Instance.SetMaxHearts(Hearts);
        }

        public void FightEnd(Enemy enemy, FightResults res)
        {
            CanMove = true;
            if (res == FightResults.Win)
            {
                Gold += enemy.Reward;
            }
        }
    }
}