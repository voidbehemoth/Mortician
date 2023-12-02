using SML;
using HarmonyLib;
using Game.Interface;
using System.Text.RegularExpressions;
using System;

namespace Mortician
{
    [Mod.SalemMod]
    public class Main
    {
        public static void Start()
        {
            Mortician.Utils.Logger.Log(ModInfo.PLUGIN_NAME + " has loaded!");
        }
    }


    public static class ModInfo
    {
        public const string PLUGIN_GUID = "Mortician";

        public const string PLUGIN_NAME = "Mortician";

        public const string PLUGIN_VERSION = "1.0.0";
    }

    [HarmonyPatch(typeof(LastWillPanel), nameof(LastWillPanel.HandleOnRaiseSendToChat))]
    public class RemoveCommentsFromWillPaste
    {
        [HarmonyPrefix]
        public static void Prefix(ref string text)
        {
            if (!ModSettings.GetBool("Remove Comments When Pasting Will", "voidbehemoth.mortician")) return;

            string sanitizedCommentCharacter = Regex.Replace(ModSettings.GetString("Comment Prefix", "voidbehemoth.mortician"), "[-.\\+*?\\[^\\]$(){}=!<>|:\\\\]", "\\\\$0");

            text = Regex.Replace(text, $"{ sanitizedCommentCharacter }.*$", "");
        }
    }
}