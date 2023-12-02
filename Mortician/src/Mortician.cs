using SML;

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
}