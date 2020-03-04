using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using ExileCore;
using SharpDX;

// ReSharper disable UnusedType.Global
namespace OnlyGoodMaps
{
    public class Core : BaseSettingsPlugin<Settings>
    {
        private enum MapTypes
        {
            Best, // S tier
            Good, // A tier
            Skip, // Town, Hideout, Campaign
            Cancer, // Bad layouts
            Unknown, // Everything else
        }
        
        private IEnumerable<string> STierMaps { get; } = new List<string>
        {
            "Acid Caverns",
            "Alleyways",
            "Arachnid Nest",
            "Arcade",
            "Arid Lake",
            "Ashen Wood",
            "Atoll",
            "Beach",
            "Bog",
            "Burial Chamber's",
            "Caldera",
            "Canyon",
            "Cemetery",
            "Channel",
            "City Square",
            "Courthouse",
            "Coves",
            "Crimson Temple",
            "Crystal Ore",
            "Dark Forest",
            "Dunes",
            "Estuary",
            "Excavation",
            "Fields",
            "Fungal Hollow",
            "Ghetto",
            "Glacier",
            "Graveyard",
            "Grotto",
            "Haunted Mansion",
            "Iceberg",
            "Infested Valley",
            "Jungle Valley",
            "Lair",
            "Lava Lake",
            "Leyline",
            "Lighthouse",
            "Lookout",
            "Marshes",
            "Mesa",
            "Moon Temple",
            "Mud Geyser",
            "Park",
            "Peninsula",
            "Phantasmagoria",
            "Plateau",
            "Primordial Pools",
            "Racecourse",
            "Ramparts",
            "Reef",
            "Sepulchre",
            "Shore",
            "Siege",
            "Spider Forest",
            "Spider Lair",
            "Strand",
            "Sulphur Vents",
            "Thicket",
            "Toxic Sewer",
            "Tropical Island",
            "Underground River",
            "Underground Sea",
            "Waste Pool",
            "Waterways",
            "Wharf",
        };
        
        private IEnumerable<string> ATierMaps { get; } = new List<string>
        {
            "Arachnid Tomb",
            "Barrows",
            "Basilica",
            "Bazaar",
            "Belfry",
            "Carcass",
            "Castle Ruins",
            "Chateau",
            "Collonade",
            "Crater",
            "Defiled Cathedral",
            "Desert Spring",
            "Dig",
            "Geode",
            "Laboritory",
            "Malformation",
            "Mausoleum",
            "Port",
            "Primordial Blocks",
            "Promenade",
            "Relic Chambers",
            "Shipyard",
            "Summit",
            "Temple",
            "Terrace",
            "Tower",
            "Vault",
            "Volcano",
        };

        private IEnumerable<string> UniqueMaps { get; } = new List<string>
        {
            "Acton's Nightmare",
            "Caer blaid",
            "Coward's Trial",
            "Death and Taxes",
            "Doryanis Machinarium",
            "Hall of the Grand Master's",
            "Hallowed Ground",
            "Maelstorm of Chaos",
            "Mao Kun",
            "Oba's Cursed Trove",
            "Olmec's Sanctum",
            "Perandus Manor",
            "Pillars of Arun",
            "Poorjoys",
            "Putrid Cloister",
            "Twilight Temple",
            "Vault's of Atziri",
            "Vinktar Square",
            "Whaka",
        };
        
        private IEnumerable<string> CancerMaps { get; } = new List<string>
        {
            "Academy",
            "Ancient City",
            "Arena",
            "Armoury",
            "Bone Crypt",
            "Cage",
            "Cells",
            "Colloseum",
            "Conservatory",
            "Coral Ruins",
            "Core",
            "Courtyard",
            "Cursed Crypt",
            "Desert",
            "Dungeon",
            "Factory",
            "Flooded Mine",
            "Gardens",
            "Ivory Temple",
            "Lava Chamber",
            "Maze",
            "Mineral Pools",
            "Museum",
            "Necropolis",
            "Orchard",
            "Overgrown Ruin",
            "Overgrown Shrine",
            "Palace",
            "Pen",
            "Pier",
            "Pit",
            "Plaza",
            "Precinct",
            "Residence",
            "Scriptorium",
            "Shrine",
            "Sunken City",
            "Vaal Pyramid",
            "Vaal Temple",
            "Villa",
            "Wasteland",
        };

        private MapTypes CurrentZone { get; set; }
        
        public Core()
        {
            Name = "OnlyGoodMaps";
        }

        public override bool Initialise()
        {
            return true;
        }
        
        public override void Render()
        {
            if (!Settings.Enable ||
                !Settings.DrawEnable)
                return;
            Color color; 
            switch (CurrentZone)
            {
                case MapTypes.Skip:
                    if (MenuWindow.IsOpened)
                        color = Color.DarkGray;
                    else
                        return;
                    break;
                case MapTypes.Unknown:
                    color = Color.Yellow;
                    break;
                case MapTypes.Cancer:
                    color = Color.Red;
                    break;
                case MapTypes.Good:
                case MapTypes.Best:
                    if (!Settings.DrawEnable)
                        return;
                    color = Color.DarkGreen;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var rect = new RectangleF(
                Settings.MapFrameX0,
                Settings.MapFrameY0,
                Settings.MapFrameWidth,
                Settings.MapFrameHeight);
            Graphics.DrawFrame(rect, color, 5);
        }

        public override void AreaChange(AreaInstance area)
        {
            base.AreaChange(area);
            if (!Settings.Enable)
                return;
            CurrentZone = MapTypes.Skip;
            if (area.HasWaypoint || area.IsHideout || area.IsTown || area.RealLevel < 68) 
                CurrentZone = MapTypes.Skip;
            else if (Contains(UniqueMaps, area.Name))
                CurrentZone = MapTypes.Skip;
            else if (Contains(CancerMaps, area.Name))
            {
                CurrentZone = MapTypes.Cancer;
                Play(DirectoryFullName + @"\Media\Cancer.wav");
            }
            else if (Contains(STierMaps, area.Name))
                CurrentZone = MapTypes.Best;
            else if (Contains(ATierMaps, area.Name))
                CurrentZone = MapTypes.Good;
            else if (area.RealLevel >= 81) // t14+ = 81+ area lvl
                CurrentZone = MapTypes.Unknown;
        }

        private static bool Contains(IEnumerable<string> list, string str)
        {
            var str2 = TrimString(str);
            return list
                .Select(TrimString)
                .Any(line2 => LevenshteinDistance.Compute(line2, str2) <= 1);
        }

        private static string TrimString(string str)
        {
            return str.ToLower().Replace("\'", "").Replace(" ", "");
        }

        private static void Play(string file)
        {
            if (File.Exists(file) && file.EndsWith(".wav")) 
                new SoundPlayer(file).Play();
        }
    }
}