namespace _ROOT.Scripts.GlobalWorld
{
    using System;
    using Game;
    using UnityEngine;
    public class LevelStarter : MonoBehaviour   
    {
        private void Awake()
        {
            CameraController.Instance.FocusWorldCamera(PlayerProvider.Instance.Player.transform);
            CameraController.Instance.EnableWorldCamera();
        }
    }
}