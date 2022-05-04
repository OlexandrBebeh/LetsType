using System;
using _ROOT.Scripts.Game;
using UnityEngine;

namespace _ROOT.Scripts.GlobalWorld
{
    public class LevelStarter : MonoBehaviour   
    {
        
        private void Awake()
        {
            CameraController.Instance.FocusWorldCamera(PlayerProvider.Instance.Player.transform);
            CameraController.Instance.EnableWorldCamera();
        }
    }
}