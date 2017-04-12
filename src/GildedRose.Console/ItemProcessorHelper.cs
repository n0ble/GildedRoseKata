namespace GildedRose.Console
{
    public class ItemProcessorHelper
    {
        public static void UpdateSellInAndQuality(Item item)
        {
            item.SellIn--;
            Inventory.AdjustQualityToAllowedBoundaries(item);
        }
    }
}
