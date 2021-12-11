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

        public void TakeItem(string name) {
            foreach (InventoryItem item in inventoryItems) {
                if (item.Name == name) {
                    inventoryItems.Remove(item);
                    return;
                }
            }
        }

        public void TakeItem(int slot) {
            foreach (InventoryItem item in inventoryItems) {
                if (item.Slot == slot) {
                    inventoryItems.Remove(item);
                    return;
                }
            }
        }

    }
}