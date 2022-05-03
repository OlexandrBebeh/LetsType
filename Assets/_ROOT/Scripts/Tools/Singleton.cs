using System;
using UnityEngine;

namespace _ROOT.Scripts.Tools
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = (T) this;
            }
            else
            {
                DestroyImmediate(this);
            }
        }
    }
}