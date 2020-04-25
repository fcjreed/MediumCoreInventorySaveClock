using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace MediumCoreInventorySaveClock
{
    public class Config : ModConfig
        {
            [Header("Clock Positioning")]
            [Label("Enable Real World Clock")]
            [Tooltip("Enables or disables showing of the local clock.")]
            [DefaultValue(true)]
            public bool clockEnabled;

            [Label("The display format of the Clock.")]
            [Tooltip("Be careful what format you put here as the text will overlay if it's too large. Supports DateTime format.")]
            [DefaultValue("h:mm tt")]
            public string clockFormat;

            [Label("MiniMap Y offset")]
            [Tooltip("Changes the offset in pixels of the veritcal axis.")]
            [DefaultValue(14)]
            public int offset;

            [Label("Real World Timer Location")]
            [Tooltip("The position of the Real World Clock. Default right side of screen.")]
            [DefaultValue(typeof(Vector2), "-1, -1")]
            public Vector2 position;

            public override ConfigScope Mode => ConfigScope.ClientSide;
        }

}