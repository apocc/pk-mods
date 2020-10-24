using UnityEngine;
using UnityModManagerNet;

namespace WeaponSetHotkeys
{
    internal static class Gui
    {
        internal static void OnGUI(bool enabled, UnityModManager.ModEntry modEntry, Settings settings)
        {
            if (!enabled) return;

            GUILayout.BeginVertical();

            GUILayout.Label("There is currently no key validation. Make sure other installed mods don't use the same key!");

            GUILayout.BeginHorizontal();
            GUILayout.Label("Key for weapon set 1:", GUILayout.ExpandWidth(false));
            GUI.SetNextControlName("__apocc__tw__set00");
            settings.KeySet00 = GUILayout.TextField(settings.KeySet00, GUILayout.Width(128));
            GUILayout.Space(30);
            if (GUILayout.Button("Left shift", GUILayout.Width(128)))
                settings.KeySet00 = KeyCode.LeftShift.ToString();
            if (GUILayout.Button("Right shift", GUILayout.Width(128)))
                settings.KeySet00 = KeyCode.RightShift.ToString();
            if (GUILayout.Button("Tab", GUILayout.Width(128)))
                settings.KeySet00 = KeyCode.Tab.ToString();

            GUILayout.Space(20);
            if (GUILayout.Button("Clear", GUILayout.Width(128)))
                settings.KeySet00 = KeyCode.None.ToString();

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Key for weapon set 2:", GUILayout.ExpandWidth(false));
            GUI.SetNextControlName("__apocc__tw__set01");
            settings.KeySet01 = GUILayout.TextField(settings.KeySet01, GUILayout.Width(128));
            GUILayout.Space(30);
            if (GUILayout.Button("Left shift", GUILayout.Width(128)))
                settings.KeySet01 = KeyCode.LeftShift.ToString();
            if (GUILayout.Button("Right shift", GUILayout.Width(128)))
                settings.KeySet01 = KeyCode.RightShift.ToString();
            if (GUILayout.Button("Tab", GUILayout.Width(128)))
                settings.KeySet01 = KeyCode.Tab.ToString();

            GUILayout.Space(20);
            if (GUILayout.Button("Clear", GUILayout.Width(128)))
                settings.KeySet01 = KeyCode.None.ToString();

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Key for weapon set 3:", GUILayout.ExpandWidth(false));
            GUI.SetNextControlName("__apocc__tw__set02");
            settings.KeySet02 = GUILayout.TextField(settings.KeySet02, GUILayout.Width(128));
            GUILayout.Space(30);
            if (GUILayout.Button("Left shift", GUILayout.Width(128)))
                settings.KeySet02 = KeyCode.LeftShift.ToString();
            if (GUILayout.Button("Right shift", GUILayout.Width(128)))
                settings.KeySet02 = KeyCode.RightShift.ToString();
            if (GUILayout.Button("Tab", GUILayout.Width(128)))
                settings.KeySet02 = KeyCode.Tab.ToString();

            GUILayout.Space(20);
            if (GUILayout.Button("Clear", GUILayout.Width(128)))
                settings.KeySet02 = KeyCode.None.ToString();

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Key for weapon set 4:", GUILayout.ExpandWidth(false));
            GUI.SetNextControlName("__apocc__tw__set03");
            settings.KeySet03 = GUILayout.TextField(settings.KeySet03, GUILayout.Width(128));
            GUILayout.Space(30);
            if (GUILayout.Button("Left shift", GUILayout.Width(128)))
                settings.KeySet03 = KeyCode.LeftShift.ToString();
            if (GUILayout.Button("Right shift", GUILayout.Width(128)))
                settings.KeySet03 = KeyCode.RightShift.ToString();
            if (GUILayout.Button("Tab", GUILayout.Width(128)))
                settings.KeySet03 = KeyCode.Tab.ToString();

            GUILayout.Space(20);
            if (GUILayout.Button("Clear", GUILayout.Width(128)))
                settings.KeySet03 = KeyCode.None.ToString();

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Key weapon cycle:", GUILayout.ExpandWidth(false));
            GUILayout.Space(17);
            GUI.SetNextControlName("__apocc__tw__toggle");
            settings.KeySetToggle = GUILayout.TextField(settings.KeySetToggle, GUILayout.Width(128));
            GUILayout.Space(30);
            if (GUILayout.Button("Left shift", GUILayout.Width(128)))
                settings.KeySetToggle = KeyCode.LeftShift.ToString();
            if (GUILayout.Button("Right shift", GUILayout.Width(128)))
                settings.KeySetToggle = KeyCode.RightShift.ToString();
            if (GUILayout.Button("Tab", GUILayout.Width(128)))
                settings.KeySetToggle = KeyCode.Tab.ToString();

            GUILayout.Space(20);
            if (GUILayout.Button("Clear", GUILayout.Width(128)))
                settings.KeySetToggle = KeyCode.None.ToString();

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("For all selected chararacters:", GUILayout.ExpandWidth(false));
            settings.EnableAllSelectedCharacters = GUILayout.Toggle(settings.EnableAllSelectedCharacters, "");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Enable verbose logging:", GUILayout.ExpandWidth(false));
            settings.EnableVerboseLogging = GUILayout.Toggle(settings.EnableVerboseLogging, "");
            GUILayout.EndHorizontal();

            if (Event.current.keyCode != KeyCode.None && Event.current.keyCode != KeyCode.Tab)
            {
                switch (GUI.GetNameOfFocusedControl())
                {
                    case "__apocc__tw__set00":
                        settings.KeySet00 = Event.current.keyCode.ToString();
                        break;
                    case "__apocc__tw__set01":
                        settings.KeySet01 = Event.current.keyCode.ToString();
                        break;
                    case "__apocc__tw__set02":
                        settings.KeySet02 = Event.current.keyCode.ToString();
                        break;
                    case "__apocc__tw__set03":
                        settings.KeySet03 = Event.current.keyCode.ToString();
                        break;
                    case "__apocc__tw__toggle":
                        settings.KeySetToggle = Event.current.keyCode.ToString();
                        break;
                }
            }

            GUILayout.EndVertical();
        }
    }
}
