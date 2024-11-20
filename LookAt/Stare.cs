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
        public static void LookAtPlayer() // Original code remade from xKiraiChan's code | https://github.com/Astrum-Project/AstralStare/blob/master/AstralStare.cs |
        { //SelectedPlayer.PlayerObject.transform
            Transform te = GameObject.Find(QuickMenuAPI.SelectedPlayerID).transform;

            if (te != null)
            { //
                Transform Localplayer = util.GetLocalPlayerAvatar().transform;
                Localplayer.LookAt(te);
            }
            else
            {
                main._update -= LookAtPlayer;
                GameObject cv = util.GetLocalPlayerAvatar();
                cv.GetComponent<LookAtIK>().enabled = true;
                return;
            }
            return;
        }
    }
}
