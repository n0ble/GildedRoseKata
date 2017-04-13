using GildedRose.Console.Contract;

namespace GildedRose.Console.Processors
{
	public class GrowingToTheLimitQualityItemProcessor : IItemChangable
	{
		private readonly ISellInDecrementor _sellInDecrementor;
		private readonly IQualityToBoundariesAligner _qualityToBoundariesAligner;

		public GrowingToTheLimitQualityItemProcessor(ISellInDecrementor sellInDecrementor,
			IQualityToBoundariesAligner qualityToBoundariesAligner)
		{
			_sellInDecrementor = sellInDecrementor;
			_qualityToBoundariesAligner = qualityToBoundariesAligner;
		}

		public void UpdateSellInAndQuality(Item item)
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

			_qualityToBoundariesAligner.AlignQualityToBoundaries(item);
			_sellInDecrementor.DecrementSellIn(item);
		}
	}
}
