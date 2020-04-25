using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace MediumCoreInventorySaveClock
{
	public class Inventory : ModPlayer
	{
		private Dictionary<string, DataHolder> playerData = new Dictionary<string, DataHolder>();
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

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			DataHolder holder = new DataHolder();
			if (this.player.difficulty == 1)
			{
				buildData(ref holder.inventoryState, ref this.player.inventory);
				buildData(ref holder.equipState, ref this.player.armor);
				buildData(ref holder.miscState, ref this.player.miscEquips);
				buildData(ref holder.equipDye, ref this.player.dye);
				buildData(ref holder.miscDye, ref this.player.miscDyes);
				this.playerData.Add(this.player.name, holder);
			}

			return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
		}

		public DataHolder getPlayerData(Player player) {
			if (this.playerData.ContainsKey(player.name)){
				return this.playerData[player.name];
			}
			return null;
		}

	}
}