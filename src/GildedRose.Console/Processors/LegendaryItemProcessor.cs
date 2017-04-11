namespace GildedRose.Console.Processors
{
    public class LegendaryItemProcessor : IItemProcessor
    {
        public void UpdateQuality(Item item)
        {
            // legendary item never has to be sold or decreases in Quality
        }
    }
}
