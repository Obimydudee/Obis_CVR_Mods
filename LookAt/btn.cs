using BTKUILib;
using BTKUILib.UIObjects;
using BTKUILib.UIObjects.Components;
using RootMotion.FinalIK;
using ABI_RC.Core.Networking.IO.Social;
using UnityEngine;

namespace LookAt
{
    internal class btn
    {
        public static ToggleButton stare;
        internal static Category SelectedUsrCat = QuickMenuAPI.PlayerSelectPage.AddCategory("LookAt");

        public static void init()
        {
            stare = SelectedUsrCat.AddToggle($"stare at {QuickMenuAPI.SelectedPlayerName}", "", false);
            stare.OnValueUpdated += b =>
            {
                if (Friends.FriendsWith(QuickMenuAPI.SelectedPlayerID))
                {
                    if (b)
                    {



                        Transform me = util.GetLocalPlayerAvatar().transform;
                        if (me != null)
                        {

                            main._update += Stare.LookAtPlayer;
                            GameObject cv = util.GetLocalPlayerAvatar();
                            cv.GetComponent<LookAtIK>().enabled = false;
                        }
                    }
                    else
                    {
                        main._update -= Stare.LookAtPlayer;
                        GameObject cv = util.GetLocalPlayerAvatar();
                        cv.GetComponent<LookAtIK>().enabled = true;
                        cv.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    }
                }
                else { stare.ToggleValue = false; QuickMenuAPI.ShowAlertToast($"You are not friends with {QuickMenuAPI.SelectedPlayerName}!"); }
                

            };
        }
    }
}
