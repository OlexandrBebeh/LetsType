using System;
using _ROOT.Scripts.Game;
using _ROOT.Scripts.Saves.Player;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class NextLevelController : MonoBehaviour
    {
        [SerializeField] private int Price;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponentInParent<Player>();
            if (player && PlayerSavable.Instance.Gold > Price)
            {
                PlayerSavable.Instance.Gold -= Price;
                GameController.Instance.StartNextLevel();
            }
        }
    }
}