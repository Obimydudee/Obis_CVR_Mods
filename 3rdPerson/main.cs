using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace _3rdPerson
{
    public class main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonCoroutines.Start(WaitForCoHTML());
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                THRDP.CameraSetup++;
                if (THRDP.CameraSetup > 2)
                {
                    THRDP.CameraSetup = 0;
                }
            }
        }

        public static IEnumerator WaitForCoHTML()
        {
            // Waits till it finds the CoHTML before it initializes
            while (GameObject.Find("/Cohtml") == null)
            {
                yield return null;
            }
            MelonLogger.Msg("Got CoHTML!");
            THRDP.Start();
 
        }
    }
}
