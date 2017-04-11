namespace GildedRose.Console.Processors
{
    public class GrowingQualityItemProcessor : BaseItemProcessor
    {
        public override void UpdateQuality(Item item)
        {
            var increment = item.SellIn > 0 ? 1 : 2;
            item.Quality += increment;
    
            base.UpdateQuality(item);
        }
    }
}
