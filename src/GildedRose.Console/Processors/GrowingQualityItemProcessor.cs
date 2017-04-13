using GildedRose.Console.Contract;

namespace GildedRose.Console.Processors
{
	public class GrowingQualityItemProcessor : IItemChangable
	{
		private readonly ISellInDecrementor _sellInDecrementor;
		private readonly IQualityToBoundariesAligner _qualityToBoundariesAligner;

		public GrowingQualityItemProcessor(ISellInDecrementor sellInDecrementor,
			IQualityToBoundariesAligner qualityToBoundariesAligner)
		{
			_sellInDecrementor = sellInDecrementor;
			_qualityToBoundariesAligner = qualityToBoundariesAligner;
		}

		public void UpdateSellInAndQuality(Item item)
		{
			var increment = item.SellIn > 0 ? 1 : 2;
			item.Quality += increment;

			_qualityToBoundariesAligner.AlignQualityToBoundaries(item);
			_sellInDecrementor.DecrementSellIn(item);
		}
	}
}
