using System.Windows.Forms;
using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace OnlyGoodMaps
{
    public class Settings : ISettings
    {
        public Settings()
        {
            Enable = new ToggleNode(false);
            ShowGoodMaps = new ToggleNode(true);
            DrawEnable = new ToggleNode(true);
            MapFrameX0 = new RangeNode<int>(1645, 0, 3840);
            MapFrameY0 = new RangeNode<int>(9, 0, 2160);
            MapFrameWidth = new RangeNode<int>(266, 100, 600);
            MapFrameHeight = new RangeNode<int>(266, 100, 600);
        }

        #region About

        [Menu("OnlyGoodMaps plugin. Green = good, Red = bad, Yellow = outdated", 900)] 
        public EmptyNode AboutRoot { get; set; }

        [Menu("Enable", 901, 900)] 
        public ToggleNode Enable { get; set; }
        
        [Menu("ShowGoodMaps", 902, 900)] 
        public ToggleNode ShowGoodMaps { get; set; }
        
        [Menu("DrawEnable", 903, 900)] 
        public ToggleNode DrawEnable { get; set; }
        
        [Menu("Where to draw minimap overlay", 1000)]
        public EmptyNode MapFrameRoot { get; set; }

        [Menu("Top left X", "", 1010, 1000)] 
        public RangeNode<int> MapFrameX0 { get; set; }

        [Menu("Top left Y", "", 1011, 1000)] 
        public RangeNode<int> MapFrameY0 { get; set; }

        [Menu("Width", "", 1012, 1000)] 
        public RangeNode<int> MapFrameWidth { get; set; }

        [Menu("Height", "", 1013, 1000)] 
        public RangeNode<int> MapFrameHeight { get; set; }
        
        #endregion
    }
}