﻿using System.Threading.Tasks;
using UnityEngine;

namespace _ROOT.Scripts.Tools
{
    public static class Extensions
    {
        public static Task Await(this AsyncOperation op)
        {
            var tcs = new TaskCompletionSource<bool>();
            op.completed += _ => tcs.SetResult(true);
            return tcs.Task;
        }
    }
}