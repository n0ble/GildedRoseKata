namespace GildedRose.Console.Processors
{
    public class GrowingQualityItemProcessor : IItemProcessor
    {
        public void UpdateSellInAndQuality(Item item)
        {
            var increment = item.SellIn > 0 ? 1 : 2;
            item.Quality += increment;
    
            ItemProcessorHelper.UpdateSellInAndQuality(item);
        }
    }
}
