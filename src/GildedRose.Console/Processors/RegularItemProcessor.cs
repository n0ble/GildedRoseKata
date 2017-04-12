namespace GildedRose.Console.Processors
{
    public class RegularItemProcessor : IItemProcessor
    {
        public static int DegradationNormalSpeed = 1;
        public static int DegradationDoubleSpeed = 2;

        public void UpdateSellInAndQuality(Item item)
        {
            var decrement = item.SellIn > 0 
                ? DegradationNormalSpeed 
                : DegradationDoubleSpeed;

            item.Quality -= decrement;

            ItemProcessorHelper.UpdateSellInAndQuality(item);
        }
    }
}
