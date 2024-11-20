using BTKUILib;
using BTKUILib.UIObjects;
using BTKUILib.UIObjects.Components;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SanAndreasFogFix
{
    internal class btn
    {
        public static Page Pageroot;
        public static SliderFloat thefog;
        public static SliderFloat thefogDis;
        public static SliderFloat thefogsDis;
        public static ToggleButton FogTogCol;
        public static ToggleButton FogTog;

        public static void setUI()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            Stream GetIconStream(string iconName) => ass.GetManifestResourceStream($"SanAndreasFogFix.Resource.{iconName}");
            QuickMenuAPI.PrepareIcon("SanAndreasFogFix", "logo", GetIconStream("gtasafog.png"));

            Pageroot = new Page("SanAndreasFogFix", "SAFF", isRootPage: true, "logo")
            {
                MenuTitle = "SanAndreasFogFix",
                MenuSubtitle = ""
            };
            Category cat1 = Pageroot.AddCategory("SAFF");

            FogTog = cat1.AddToggle("Fog Toggle", "", true);
            FogTog.OnValueUpdated += newbool =>
            {
                if (newbool)
                {
                    RenderSettings.fog = true;
                }
                else
                {
                    RenderSettings.fog = false;
                }
            };

            thefog = cat1.AddSlider("Fog Density", "", RenderSettings.fogDensity, 0f, 100f, 2);
            thefog.OnValueUpdated += newValue =>
            {
                RenderSettings.fogDensity = newValue;
            };

            thefogDis = cat1.AddSlider("Fog End Distance", "", RenderSettings.fogEndDistance, 0f, 1000f, 2);
            thefogDis.OnValueUpdated += newValue =>
            {
                RenderSettings.fogEndDistance = newValue;
            };

            thefogsDis = cat1.AddSlider("Fog Start Distance", "", RenderSettings.fogStartDistance, 0f, 1000f, 2);
            thefogsDis.OnValueUpdated += newValue =>
            {
                RenderSettings.fogStartDistance = newValue;
            };

            FogTogCol = cat1.AddToggle("Fog Night", "", false);
            Color defaultFogCol = RenderSettings.fogColor;
            FogTogCol.OnValueUpdated += newbool =>
            {
                if (newbool)
                {
                    RenderSettings.fogColor = new Color(0.02f, 0.02f, 0.04f);
                }
                else
                {
                    RenderSettings.fogColor = new Color(0.651f, 0.651f, 0.651f, 1f);
                }
            };

            variables.has = true;


        }
    }
}
