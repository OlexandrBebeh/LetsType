using System;
using JetBrains.Annotations;
using UnityEngine;

namespace _ROOT.Scripts.Tools
{
    [AttributeUsage(AttributeTargets.Method), MeansImplicitUse]
    public class EditorButtonAttribute : PropertyAttribute
    {
    }
}