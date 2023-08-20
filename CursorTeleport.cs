
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace CursorTeleport
{
   
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {

        private ModConfig Config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        
        public override void Entry(IModHelper helper)
        {
            this.Config = helper.ReadConfig<ModConfig>();
            helper.Events.Input.ButtonsChanged += this.OnButtonsChanged;
        }

        private void OnButtonsChanged(object sender, ButtonsChangedEventArgs e)
        {
            if (this.Config.ToggleKey.JustPressed())
            {
                var x = e.Cursor.AbsolutePixels.X;
                var y = e.Cursor.AbsolutePixels.Y;
                Game1.player.position.X = x - 32;
                Game1.player.position.Y = y;
            }
        }
    }
}