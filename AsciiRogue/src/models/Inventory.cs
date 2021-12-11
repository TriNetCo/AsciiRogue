using System;
using System.Linq;
using System.Collections;

namespace AsciiRogue
{
    public class Inventory
    {
        public int MaxSlots = 5;

        public ArrayList inventoryItems = new ArrayList();

        public void GiveItem(InventoryItem item) {
            if (inventoryItems.Count < MaxSlots) {
                inventoryItems.Add(item);
                return;
            }
            // Notify Player: Inventory full
        }

        public void RemoveItem(string name) {
            foreach (InventoryItem item in inventoryItems) {
                if (item.Name == name) {
                    inventoryItems.Remove(item);
                    return;
                }
            }
        }

        public void RemoveItem(int slot) {
            foreach (InventoryItem item in inventoryItems) {
                if (item.Slot == slot) {
                    inventoryItems.Remove(item);
                    return;
                }
            }
        }


        public int Count() {
            return inventoryItems.Count;
        }


        public override string ToString()
        {
            string[] inventoryLines = FileUtils.readMenuFromResources("inventory_screen");

            for (int i = 0; i < inventoryItems.Count; i++) {
                InventoryItem item = (InventoryItem) inventoryItems[i];
                inventoryLines[i+3] = "I  - " + item.Name.PadRight(12) + "I";
            }

            return String.Join("\n", inventoryLines);
        }

    }
}