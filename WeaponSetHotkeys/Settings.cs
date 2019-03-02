using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityModManagerNet;

namespace WeaponSetHotkeys
{
    public sealed class Settings
    {
        internal const string Filename = "settings.xml";
        private UnityModManager.ModEntry.ModLogger _log;

        private string _keySet00;
        private string _keySet01;
        private string _keySet02;
        private string _keySet03;
        private string _keySetToggle;

        public string KeySet00 { get => _keySet00; set => SetProperty(ref _keySet00, value); }
        public string KeySet01 { get => _keySet01; set => SetProperty(ref _keySet01, value); }
        public string KeySet02 { get => _keySet02; set => SetProperty(ref _keySet02, value); }
        public string KeySet03 { get => _keySet03; set => SetProperty(ref _keySet03, value); }
        public string KeySetToggle { get => _keySetToggle; set => SetProperty(ref _keySetToggle, value); }

        [XmlAttribute("verbose")]
        public bool EnableVerboseLogging { get; set; }

        #region key codes
        [XmlIgnore]
        public KeyCode KeyCodeSet00 { get; set; }
        [XmlIgnore]
        public KeyCode KeyCodeSet01 { get; set; }
        [XmlIgnore]
        public KeyCode KeyCodeSet02 { get; set; }
        [XmlIgnore]
        public KeyCode KeyCodeSet03 { get; set; }
        [XmlIgnore]
        public KeyCode KeyCodeToggle { get; set; }
        #endregion

        public void SetLog(UnityModManager.ModEntry.ModLogger log) => _log = log;

        private void SetProperty(ref string prop, string value, [CallerMemberName]string propertyName = null)
        {
            if (ReferenceEquals(prop, value)) return;
            prop = value;

            if (propertyName == null)
            {
                if (EnableVerboseLogging) _log.Warning("Settings.SetProperty => propertyName is null!");
                return;
            }

            if (!Enum.TryParse(prop, out KeyCode kc))
            {
                if (EnableVerboseLogging) _log.Warning($"Settings.SetProperty => Could not parse key code '{prop}' for property {propertyName}!");
                return;
            }

            if (EnableVerboseLogging) _log.Log($"Successfully parsed key code '{prop}' for property '{propertyName}'");

            switch (propertyName)
            {
                case "KeySet00": KeyCodeSet00 = kc; break;
                case "KeySet01": KeyCodeSet01 = kc; break;
                case "KeySet02": KeyCodeSet02 = kc; break;
                case "KeySet03": KeyCodeSet03 = kc; break;
                case "KeySetToggle": KeyCodeToggle = kc; break;
            }
        }

        public Settings()
        {
            var none = KeyCode.None.ToString();
            KeySet00 = KeySet01 = KeySet02 = KeySet03 = KeySetToggle = none;
        }

        public void Save(UnityModManager.ModEntry modEntry)
        {
            var path = Path.Combine(modEntry.Path, Filename);
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                new XmlSerializer(typeof(Settings)).Serialize(fs, this);
        }

        public static Settings Load(UnityModManager.ModEntry modEntry)
        {
            var path = Path.Combine(modEntry.Path, Filename);
            if (!File.Exists(path))
            {
                modEntry.Logger.Log("No settings file found, loading default settings.");
                return new Settings();
            }

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                return new XmlSerializer(typeof(Settings)).Deserialize(fs) as Settings;
        }
    }
}
