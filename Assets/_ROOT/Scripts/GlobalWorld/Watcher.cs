using System;
using _ROOT.Scripts.Game;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class Watcher : MonoBehaviour
    {
        [SerializeField] GameObject GlobalInterface;
        private void FixedUpdate()
        {
            if (GameController.Instance.GetState() == GameState.fight)
            {
                GlobalInterface.SetActive(false);
            }
            else
            {
                GlobalInterface.SetActive(true);
            }
        }
    }
}