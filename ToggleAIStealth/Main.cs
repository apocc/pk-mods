using Harmony12;
using Kingmaker;
using Kingmaker.GameModes;
using Kingmaker.UI.ActionBar;
using System;
using System.Reflection;
using UnityEngine;
using UnityModManagerNet;

namespace ToggleAIStealth
{
    public static class Main
    {
        public static string Sepatator = "---------------";
        public static string ModTitle = "ToggleAIStealth";
        public static bool enabled;

        public static bool isModKeyPressed;
        public static bool canShowTooltip;
        public static Settings Settings;
        public static UnityModManager.ModEntry.ModLogger Log;

        public static void LogException(Exception e) => Log?.Error($"{Sepatator}{ModTitle}\n{e.Message}:\n{e.StackTrace}\n{Sepatator}");

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Log = modEntry.Logger;

            try
            {
                LoadSettings(modEntry);

                var h = HarmonyInstance.Create(modEntry.Info.Id);
                h.PatchAll(Assembly.GetExecutingAssembly());

                modEntry.OnGUI = (UnityModManager.ModEntry me) => Gui.OnGUI(enabled, me, Settings);
                modEntry.OnSaveGUI = OnSave;
                modEntry.OnToggle = OnToggle;

                return true;
            }
            catch (Exception e)
            {
                LogException(e);
            }

            return false;
        }

        public static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            enabled = value;
            return true;
        }

        public static void OnSave(UnityModManager.ModEntry modEntry)
        {
            try
            {
                Settings.Save(modEntry);
            }
            catch (Exception e)
            {
                Log.Error($"Could not save settings!");
                LogException(e);
            }
        }

        public static void LoadSettings(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var s = Settings.Load(modEntry);
                if (s == null)
                {
                    Log.Warning("Could not parse settings object!");
                    Settings = new Settings();
                }

                Settings = s;
            }
            catch (Exception e)
            {
                Log.Error($"Could not load settings!");
                LogException(e);
            }
        }

        [HarmonyPatch(typeof(UnityModManager.UI), "Update")]
        public static class UnityModManager_UI_Update_Patch
        {
            public static void Postfix(UnityModManager.UI __instance)
            {
                if (!enabled)
                    return;

                try
                {
                    if (Game.Instance.CurrentMode != GameModeType.Default && Game.Instance.CurrentMode != GameModeType.Pause)
                        return;

                    if (Input.GetKeyUp(Settings.KeyStealth))
                        new StealthSwitchButton().OnClick();

                    if (Input.GetKeyUp(Settings.KeyAI))
                        new AiSwitchButton().OnClick();
                }
                catch (Exception e)
                {
                    LogException(e);
                }
            }
        }
    }
}
