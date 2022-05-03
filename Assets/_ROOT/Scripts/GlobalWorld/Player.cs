using System;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.GlobalWorld.Enemy;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public int Hearts;
        
        [SerializeField] public int Gold;

        [SerializeField] public float Speed;

        private void Update()
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                Move();
            }
        }

        private void Move()
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal") + transform.up * Input.GetAxis("Vertical");

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (CheckForFight(other))
            {
                GameController.Instance.StartGame();
            }
        }

        private bool CheckForFight(Collision other)
        {
            if (other.gameObject.GetComponentInParent<EnemyI>())
            {
                return true;
            }

            return false;
        }
    }
}