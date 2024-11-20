using System;
using System.Collections;
using MelonLoader;
using UnityEngine;

namespace SanAndreasFogFix
{
    public class main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonCoroutines.Start(WaitForCoHTML());
        }

        public override void OnLevelWasLoaded(int level)
        {
            if (variables.has)
            {
                btn.FogTog.ToggleValue = RenderSettings.fog;
                btn.thefogDis.SetSliderValue(RenderSettings.fogEndDistance);
                btn.thefogsDis.SetSliderValue(RenderSettings.fogStartDistance);
                btn.thefog.SetSliderValue(RenderSettings.fogDensity);
            }
        }

        public static IEnumerator WaitForCoHTML()
        {
            while (GameObject.Find("/Cohtml") == null)
            {
                yield return null;
            }
            btn.setUI();
        }
    }
}
