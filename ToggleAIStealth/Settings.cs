using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityModManagerNet;

namespace ToggleAIStealth
{
    public sealed class Settings
    {
        internal const string Filename = "settings.xml";

        private int _idxStealth;
        private int _idxAI;

        [XmlIgnore]
        public string[] Values { get; }

        [XmlIgnore]
        public bool IsSelectionExpandedStealth { get; set; }

        [XmlIgnore]
        public bool IsSelectionExpandedAI { get; set; }

        public int BtnIdxStealth { get => _idxStealth; set => Update(value, "stealth"); }
        public int BtnIdxAI { get => _idxAI; set => Update(value, "ai"); }

        [XmlIgnore]
        public KeyCode KeyStealth { get; private set; }

        [XmlIgnore]
        public KeyCode KeyAI { get; private set; }

        public Settings() => Values = Enum.GetNames(typeof(KeyCode)).ToArray();

        public void Init()
        {
            Update(BtnIdxStealth, "stealth");
            Update(BtnIdxAI, "ai");
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
                return new Settings();

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                return new XmlSerializer(typeof(Settings)).Deserialize(fs) as Settings;
        }

        private void Update(int value, string type)
        {
            switch (type)
            {
                case "ai":
                    _idxAI = value;
                    KeyAI = (KeyCode)Enum.Parse(typeof(KeyCode), Values[value]);
                    break;
                case "stealth":
                    _idxStealth = value;
                    KeyStealth = (KeyCode)Enum.Parse(typeof(KeyCode), Values[value]);
                    break;
            }
        }
    }
}
