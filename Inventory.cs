using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace MediumCoreInventorySaveClock
{
	public class Inventory : ModPlayer
	{
		public static Dictionary<int, int> inventoryState = new Dictionary<int, int>();
		public static Dictionary<int, int> equipState = new Dictionary<int, int>();
		public static Dictionary<int, int> miscState = new Dictionary<int, int>();
		public static Dictionary<int, int> equipDye = new Dictionary<int, int>();
		public static Dictionary<int, int> miscDye = new Dictionary<int, int>();

		public Inventory()
		{
		}

		private void buildData(ref Dictionary<int, int> build, Item[] items)
		{
			for (int x = 0; x < items.Length; x++)
			{
				build[x] = items[x].netID;
			}
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (player.difficulty == 1)
			{
				buildData(ref inventoryState, player.inventory);
				buildData(ref equipState, player.armor);
				buildData(ref miscState, player.miscEquips);
				buildData(ref equipDye, player.dye);
				buildData(ref miscDye, player.miscDyes);
			}

			return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
		}
	}
}