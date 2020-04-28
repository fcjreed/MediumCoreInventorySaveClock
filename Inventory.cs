using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using System.Collections.Generic;


namespace MediumCoreInventorySaveClock
{
	public class Inventory : ModPlayer
	{
		public DataHolder playerData;
		public bool resetCache = true;
		public Inventory()
		{
		}

		private void buildData(ref Dictionary<int, int> build, ref Item[] items)
		{
			for (int x = 0; x < items.Length; x++)
			{
				build[x] = items[x].netID;
			}
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (MediumCoreInventorySaveClock.ResetDeathCache.JustPressed) {
				this.resetCache = !this.resetCache;
				Main.NewText("Death cache has been set to " + this.resetCache + ".", Color.White);
			}
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (Main.LocalPlayer.name.Equals(this.player.name) && this.player.difficulty == 1)
			{
				if (this.resetCache) {
					this.playerData = new DataHolder();
					buildData(ref this.playerData.inventoryState, ref this.player.inventory);
					buildData(ref this.playerData.equipState, ref this.player.armor);
					buildData(ref this.playerData.miscState, ref this.player.miscEquips);
					buildData(ref this.playerData.equipDye, ref this.player.dye);
					buildData(ref this.playerData.miscDye, ref this.player.miscDyes);
					this.resetCache = false;
				}
			}

			return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
		}

	}
}