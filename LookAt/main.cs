using ABI_RC.Systems.Camera.VisualMods;
using MelonLoader;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

namespace LookAt
{
    public class main : MelonMod
    {
        public static Action _update = () => { };   

        public override void OnUpdate() => _update();

        public override void OnInitializeMelon()
        {
            MelonCoroutines.Start(WaitForCoHTML());
        }

        

        public static IEnumerator WaitForCoHTML()
        {
            while (GameObject.Find("/Cohtml") == null)
            {
                yield return null;
            }
            btn.init();
        }


    }
}
