﻿namespace _ROOT.Scripts.Game
{
    using Tools;
    using Cinemachine;
    using UnityEngine;
    public class CameraController : Singleton<CameraController>
    {
        [SerializeField] private CinemachineVirtualCamera worldCamera;

        private void Start()
        {
            DisableWorldCamera();
        }

        public void FocusWorldCamera(Transform transform)
        {
            worldCamera.Follow = transform;
            worldCamera.LookAt = transform;
        }

        public void EnableWorldCamera()
        {
            worldCamera.gameObject.SetActive(true);
        }

        public void DisableWorldCamera()
        {
            worldCamera.gameObject.SetActive(false);
        }
    }
}