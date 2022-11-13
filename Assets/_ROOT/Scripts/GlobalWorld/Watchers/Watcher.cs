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
            if (NeedHideInterface())
            {
                GlobalInterface.SetActive(false);
            }
            else
            {
                GlobalInterface.SetActive(true);
            }
        }

        private bool NeedHideInterface()
        {
            return GameController.Instance.GetState() == GameState.fight
                   || GameController.Instance.GetState() == GameState.dialog;
        }
    }
}