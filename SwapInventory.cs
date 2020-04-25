using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MediumCoreInventorySaveClock
{
    class SwapInventory : GlobalItem
    {
        public override bool OnPickup(Item item, Player player)
        {
            Inventory inven = player.GetModPlayer<Inventory>();
            DataHolder data = inven.getPlayerData(player);
            if (data != null && player.difficulty == 1 && this.CanPickup(item, player) && data.inventoryState.Values.Any(v => -1 != v)) {
                bool foundSwap = false;
                if (item.bodySlot > 0 || item.headSlot > 0 || item.legSlot > 0 || item.accessory || item.vanity)
                {
                    foundSwap = handleSwap(item, data.equipState, ref player.armor);
                }
                else if (item.dye > 0)
                {
                    foundSwap = handleSwap(item, data.equipDye, ref player.dye);
                    if (!foundSwap)
                    {
                        foundSwap = handleSwap(item, data.miscDye, ref player.miscDyes);
                    }
                }
                else
                {
                    foundSwap = handleSwap(item, data.miscState, ref player.miscEquips);
                    if (!foundSwap)
                    {
                        foundSwap = handleSwap(item, data.inventoryState, ref player.inventory);
                    }
                }
                return foundSwap ? false : base.OnPickup(item, player);
            }
            return base.OnPickup(item, player);
        }

        private bool handleSwap(Item item, Dictionary<int, int> state, ref Item[] swap)
        {
            if (state != null && state.ContainsValue(item.netID))
            {
                Predicate<Item> empty = (Item o) => o.netID == 0;
                List<Item> currentInv = new List<Item>();
                currentInv.AddRange(swap);
                int x = state.Where(a => a.Value == item.netID).Select(kvp => kvp.Key).First();
                Item check = swap[x];
                if (check.netID != 0)
                {
                    if (currentInv.Count > 50)
                    {
                        List<Item> workingInv = currentInv.Take(50).ToList();
                        int y;
                        if (workingInv.Any(i => i.netID == 0)) {
                             y = workingInv.FindLastIndex(empty);
                        }
                        else
                        {
                            return false;
                        }
                        Item temp = check.Clone();
                        swap[x] = item;
                        swap[y] = temp;
                    }
                    else
                    {
                        int y = currentInv.FindLastIndex(empty);
                        Item temp = check.Clone();
                        swap[x] = item;
                        swap[y] = temp;
                    }
                }
                else
                {
                    swap[x] = item;
                }
                state[x]=-1;
                return true;
            }
            return false;
        }
    }
}
