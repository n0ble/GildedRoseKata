namespace GildedRose.Console.Processors
{
    public class ConjuredItemProcessor : IItemProcessor
    {
        public void UpdateSellInAndQuality(Item item)
        {
            var decrement = item.SellIn > 0
                ? RegularItemProcessor.DegradationNormalSpeed*2
                : RegularItemProcessor.DegradationDoubleSpeed*2;

            item.Quality -= decrement;

            ItemProcessorHelper.UpdateSellInAndQuality(item);
        }
    }
}
