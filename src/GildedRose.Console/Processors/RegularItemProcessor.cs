using GildedRose.Console.Contract;

namespace GildedRose.Console.Processors
{
	public class RegularItemProcessor : IItemChangable
	{
		private readonly ISellInDecrementor _sellInDecrementor;
		private readonly IQualityToBoundariesAligner _qualityToBoundariesAligner;

		public static int DegradationNormalSpeed = 1;
		public static int DegradationDoubleSpeed = 2;

		public RegularItemProcessor(ISellInDecrementor sellInDecrementor,
			IQualityToBoundariesAligner qualityToBoundariesAligner)
		{
			_sellInDecrementor = sellInDecrementor;
			_qualityToBoundariesAligner = qualityToBoundariesAligner;
		}

		public void UpdateSellInAndQuality(Item item)
		{
			var decrement = item.SellIn > 0
				? DegradationNormalSpeed
				: DegradationDoubleSpeed;

			item.Quality -= decrement;

			_qualityToBoundariesAligner.AlignQualityToBoundaries(item);
			_sellInDecrementor.DecrementSellIn(item);
		}
	}
}
