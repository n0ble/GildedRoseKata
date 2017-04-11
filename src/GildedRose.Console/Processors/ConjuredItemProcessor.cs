namespace GildedRose.Console.Processors
{
    public class ConjuredItemProcessor : BaseItemProcessor
    {
        public override void UpdateQuality(Item item)
        {
            var decrement = item.SellIn > 0
                ? RegularItemProcessor.DegradationNormalSpeed*2
                : RegularItemProcessor.DegradationDoubleSpeed*2;

            item.Quality -= decrement;

            base.UpdateQuality(item);
        }
    }
}
