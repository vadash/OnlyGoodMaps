using System.Collections;
using System.Collections.Generic;
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
        private Coroutine _mainCoroutine;

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
        }
    }
}