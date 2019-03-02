using UnityEngine;
using UnityModManagerNet;

namespace ToggleAIStealth
{
    internal static class Gui
    {
        internal static void OnGUI(bool enabled, UnityModManager.ModEntry modEntry, Settings settings)
        {
            if (!enabled) return;

            GUILayout.BeginVertical();
            settings.IsSelectionExpandedStealth = GUILayout.Toggle(settings.IsSelectionExpandedStealth, "Show key selection - Stealth", GUILayout.ExpandWidth(false));
            if (settings.IsSelectionExpandedStealth)
                settings.BtnIdxStealth = GUILayout.SelectionGrid(settings.BtnIdxStealth, settings.Values, 6);

            settings.IsSelectionExpandedAI = GUILayout.Toggle(settings.IsSelectionExpandedAI, "Show key selection - AI", GUILayout.ExpandWidth(false));
            if (settings.IsSelectionExpandedAI)
                settings.BtnIdxAI = GUILayout.SelectionGrid(settings.BtnIdxAI, settings.Values, 6);

            GUILayout.Space(20);
            GUILayout.Label($"Selected key - Stealth: {settings.Values[settings.BtnIdxStealth]}");
            GUILayout.Label($"Selected key - AI: {settings.Values[settings.BtnIdxAI]}");

            GUILayout.EndVertical();
        }
    }
}
