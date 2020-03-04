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
        }

        #region About

        [Menu("Global settings", 900)] 
        public EmptyNode AboutRoot { get; set; }

        [Menu("Enable", 901, 900)] 
        public ToggleNode Enable { get; set; }

        #endregion
      
    }
}