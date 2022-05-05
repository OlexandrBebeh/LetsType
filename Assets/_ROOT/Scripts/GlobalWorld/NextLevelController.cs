using System;
using _ROOT.Scripts.Game;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class NextLevelController : MonoBehaviour
    {
        [SerializeField] private int Price;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponentInParent<Player>();
            if (player && player.Gold > Price)
            {
                player.Gold -= Price;
                PlayerParameters.Instance.MaxHearts = player.Hearts;
                PlayerParameters.Instance.GoldAmount = player.Gold;
                PlayerParameters.Instance.HitZoneRagius = player.AttackRange;
                PlayerParameters.Instance.NeedReadFrom = true;
                GameController.Instance.StartNextLevel();
            }
        }
    }
}