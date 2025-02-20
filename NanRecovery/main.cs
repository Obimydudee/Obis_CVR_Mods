using UnityEngine;
using MelonLoader;
using ABI_RC.Core.Player;
using ABI_RC.Core.Util;
using ABI_RC.Core.UI;

namespace NanRecorevy
{
    public class main : MelonMod
    {
        public override void OnUpdate()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.F2))
            {
                EmergencyRespawn();
            }
        }

        private static GameObject LocalPlayer;
        public static GameObject GetLocalPlayer()
        {
            if (LocalPlayer == null) LocalPlayer = GameObject.Find("_PLAYERLOCAL");
            return LocalPlayer;
        }

        public static void EmergencyRespawn()
        {
            GetLocalPlayer().transform.position = new UnityEngine.Vector3(0, -1000, 0);
            CVRPlayerManager.Instance.ReloadAllAvatars();
            CVRSyncHelper.DeleteAllProps();
            MelonLogger.Msg("[EMERGENCY RESPAWN] - recovered from NaN");
            CohtmlHud.Instance.ViewDropText("NaNRecovery", "[EMERGENCY RESPAWN]", "recovered from NaN");
        }
    }
    
}
