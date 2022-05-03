using System;
using UnityEngine;

namespace _ROOT.Scripts.Landscape
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
    }
}