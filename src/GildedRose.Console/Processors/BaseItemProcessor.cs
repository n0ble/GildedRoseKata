namespace GildedRose.Console.Processors
{
    public class BaseItemProcessor : IItemProcessor
    {
        public virtual void UpdateQuality(Item item)
        {
            item.SellIn--;
            Inventory.AdjustQualityToAllowedBoundaries(item);
        }
    }
}
