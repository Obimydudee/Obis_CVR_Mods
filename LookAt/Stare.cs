using BTKUILib;
using RootMotion.FinalIK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LookAt
{
    internal class Stare
    {
        public static void LookAtPlayer() 
        { 
            Transform te = GameObject.Find(QuickMenuAPI.SelectedPlayerID)?.transform;

            if (te != null)
            { //
                Transform Localplayer = util.GetLocalPlayerAvatar().transform;
                Localplayer.LookAt(te);
            }
            else
            {
                if (btn.stare.ToggleValue)
                {
                    main._update -= LookAtPlayer;
                    GameObject cv = util.GetLocalPlayerAvatar();
                    cv.GetComponent<LookAtIK>().enabled = true;
                    cv.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    btn.stare.ToggleValue = false;

                }
                else
                {
                    QuickMenuAPI.ShowAlertToast("Null Object");
                    btn.stare.ToggleValue = false;
                }
                
                return;
            }
            return;
        }
    }
}
