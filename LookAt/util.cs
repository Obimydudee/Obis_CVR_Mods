using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace LookAt
{
    internal class util
    {
        internal static GameObject GetLocalPlayerAvatar()
        {
            Transform me = GameObject.Find($"_PLAYERLOCAL/[PlayerAvatar]").transform;
            string found = GetPlayerAvatar(me.GetChild(0).gameObject.name);
            if (LocalPlayer == null) LocalPlayer = GameObject.Find($"_PLAYERLOCAL/[PlayerAvatar]/{found}"); //CVRAvatar_{GetLocalAviID()}(Clone)
            return LocalPlayer;
        }
        private static GameObject LocalPlayer;
        private static string GetPlayerAvatar(string input)
        {
            string pattern = "^CVRAvatar_.*";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return "Player Avatar Object not found.";
            }
        }
    }
}
