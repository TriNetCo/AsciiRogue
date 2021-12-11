namespace AsciiRogue
{
    public class InventoryItem
    {

        public InventoryItem(string name) {
            Name = name;
        }

        public int Slot;
        public string Name;
        public bool Equipped;

        public int DamageMod;
        public int DefenseMod;
        public int HealthMod;
        public int ManaMod;
        public int AttackSpeedMod;
        public int CriticalHitChanceMod;
        public int CriticalHitDamageMod;

    }
}