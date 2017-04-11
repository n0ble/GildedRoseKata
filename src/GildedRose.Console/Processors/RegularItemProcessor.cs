namespace GildedRose.Console.Processors
{
    public class RegularItemProcessor : BaseItemProcessor
    {
        public static int DegradationNormalSpeed = 1;
        public static int DegradationDoubleSpeed = 2;

        public override void UpdateQuality(Item item)
        {
            var decrement = item.SellIn > 0 
                ? DegradationNormalSpeed 
                : DegradationDoubleSpeed;

            item.Quality -= decrement;

            base.UpdateQuality(item);
        }
    }
}
