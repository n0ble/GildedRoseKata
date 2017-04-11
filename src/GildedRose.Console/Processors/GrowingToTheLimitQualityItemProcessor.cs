namespace GildedRose.Console.Processors
{
    public class GrowingToTheLimitQualityItemProcessor : BaseItemProcessor
    {
        public override void UpdateQuality(Item item)
        {

            var increment = item.SellIn > 10
                ? 1
                : item.SellIn > 5
                    ? 2
                    : item.SellIn > 0
                        ? 3
                        : 0;

            item.Quality = increment != 0
                ? item.Quality + increment
                : 0;

            base.UpdateQuality(item);
        }
    }
}
