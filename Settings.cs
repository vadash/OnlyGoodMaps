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
            MapFrameX0 = new RangeNode<int>(1645, 0, 3840);
            MapFrameY0 = new RangeNode<int>(9, 0, 2160);
            MapFrameWidth = new RangeNode<int>(266, 100, 600);
            MapFrameHeight = new RangeNode<int>(266, 100, 600);
        }

        #region About

        [Menu("Global settings", 900)] 
        public EmptyNode AboutRoot { get; set; }

        [Menu("Enable", 901, 900)] 
        public ToggleNode Enable { get; set; }
        
        [Menu("Where to draw minimap overlay", 900)]
        public EmptyNode MapFrameRoot { get; set; }

        [Menu("Top left X", "", 910, 900)] 
        public RangeNode<int> MapFrameX0 { get; set; }

        [Menu("Top left Y", "", 911, 900)] 
        public RangeNode<int> MapFrameY0 { get; set; }

        [Menu("Width", "", 912, 900)] 
        public RangeNode<int> MapFrameWidth { get; set; }

        [Menu("Height", "", 913, 900)] 
        public RangeNode<int> MapFrameHeight { get; set; }
        
        #endregion
    }
}