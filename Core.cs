using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExileCore;
using ExileCore.Shared;
using ExileCore.Shared.Enums;
using SharpDX;
using ImGuiNET;

// ReSharper disable IteratorNeverReturns
// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantExtendsListEntry
// ReSharper disable UnusedType.Global

namespace LazyPricer
{
    [Obfuscation(Feature = "Apply to member * when constructor: virtualization", Exclude = false)]
    public partial class Core : BaseSettingsPlugin<Settings>
    {
        private enum MapTypes
        {
            Skip,
            Unknown,
            Cancer,
            Good,
            Best
        }
        
        private IEnumerable<string> STierMaps { get; } = new List<string>
        {
            "Arcade",
            "Toxic Sewer",
            "City Square",
            "Alleyways",
            "Beach",
            "Ashen Wood",
            "Underground Sea",
            "Dunes",
            "Burial Chamber",
        };
        
        private IEnumerable<string> ATierMaps { get; } = new List<string>
        {
            "Phantasmagoria",
            "Grotto",
            "Leyline",
            "Park",
            "Courthouse",
            "Waste Pool",
            "Acid Caverns",
            "Moon Temple",
            "Dark Forest",
            "Estuary",
            "Siege",
            "Sepulchre",
            "Canyon",
            "Crimson Temple",
            "Lair",
            "Caldera",
            "Thicket",
            "Arachnid Nest",
            "Waterways",
            "Primordial Pools",
            "Strand",
            "Wharf",
            "Atoll",
            "Tropical Island",
            "Iceberg",
            "Spider Forest",
            "Ghetto",
            "Shore",
            "Channel",
            "Coves",
            "Infested Valley",
            "Racecourse",
            "Glacier",
            "Spider Lair",
            "Crystal Ore",
            "Underground River",
            "Plateau",
            "Bog",
            "Fields",
            "Jungle Valley",
            "Arid Lake",
            "Haunted Mansion",
            "Cemetery",
            "Lighthouse",
            "Mesa",
            "Mud Geyser",
            "Peninsula",
            "Graveyard",
            "Lookout",
        };
        
        private IEnumerable<string> CancerMaps { get; } = new List<string>
        {
            "Basilica",
            "Summit",
            "Primordial Blocks",
            "Sunken City",
            "Courtyard",
            "Cage",
            "Tower",
            "Gardens",
            "Colloseum",
            "Desert Spring",
            "Arachnid Tomb",
            "Geode",
            "Palace",
            "Defiled Cathedral",
            "Relic Chambers",
            "Ancient City",
            "Carcass",
            "Shipyard",
            "Reef",
            "Lava Lake",
            "Core",
            "Bone Crypt",
            "Barrows",
            "Arena",
            "Pit",
            "Necropolis",
            "Temple",
            "Laboratory",
            "Cursed Crypt",
            "Museum",
            "Colonnade",
            "Plaza",
            "Lava Chamber",
            "Cells",
            "Fungal Hollow",
            "Excavation",
            "Marshes",
            "Sulphur Vents",
            "Ramparts",
            "Vault",
            "Pen",
            "Flooded Mine",
            "Dungeon",
            "Armoury",
            "Bazaar",
            "Port",
            "Coral Ruins",
            "Volcano",
            "Mausoleum",
            "Belfry",
            "Desert",
            "Maze",
            "Ivory Temple",
            "Residence",
            "Orchard",
            "Promenade",
            "Overgrown Shrine",
            "Overgrown Ruin",
            "Crater",
            "Pier",
            "Factory",
            "Vaal Temple",
            "Villa",
            "Scriptorium",
            "Mineral Pools",
            "Wasteland"
        };

        private MapTypes CurrentAreaQuality { get; set; }

        
        public Core()
        {
            Name = "LazyPricer";
        }

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        public override bool Initialise()
        {
            return true;
        }
        
        public override void Render()
        {
            Color color; 
            switch (CurrentAreaQuality)
            {
                case MapTypes.Skip:
                    return;
                case MapTypes.Unknown:
                    color = Color.Yellow;
                    break;
                case MapTypes.Cancer:
                    color = Color.Red;
                    break;
                case MapTypes.Good:
                    color = Color.Green;
                    break;
                case MapTypes.Best:
                    color = Color.DarkGreen;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var rect = new RectangleF(
                1645,
                9,
                266,
                266);
            Graphics.DrawFrame(rect, color, 5);
        }

        public override void AreaChange(AreaInstance area)
        {
            base.AreaChange(area);
            CurrentAreaQuality = MapTypes.Unknown;
            if (area.IsHideout || area.IsHideout || area.IsTown)
                CurrentAreaQuality = MapTypes.Skip;
            else if (Contains(CancerMaps, area.DisplayName))
            {
                CurrentAreaQuality = MapTypes.Cancer;
                DebugWindow.LogMsg("Shit map detected. Dont kill boss", 60, Color.Red);
            }
            else if (Contains(STierMaps, area.DisplayName))
                CurrentAreaQuality = MapTypes.Best;
            else if (Contains(ATierMaps, area.DisplayName))
                CurrentAreaQuality = MapTypes.Good;
        }

        private static bool Contains(IEnumerable<string> list, string str)
        {
            return list.Any(line => 
                line.ToLower().Contains(str.ToLower()) ||
                str.ToLower().Contains(line.ToLower()));
        }
    }
}