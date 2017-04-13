using GildedRose.Console.Contract;

namespace GildedRose.Console.Processors
{
	public class ConjuredItemProcessor : IItemChangable
	{
		private readonly ISellInDecrementor _sellInDecrementor;
		private readonly IQualityToBoundariesAligner _qualityToBoundariesAligner;

		public ConjuredItemProcessor(ISellInDecrementor sellInDecrementor,
			IQualityToBoundariesAligner qualityToBoundariesAligner)
		{
			_sellInDecrementor = sellInDecrementor;
			_qualityToBoundariesAligner = qualityToBoundariesAligner;
		}

		public void UpdateSellInAndQuality(Item item)
		{
			var decrement = item.SellIn > 0
				? RegularItemProcessor.DegradationNormalSpeed * 2
				: RegularItemProcessor.DegradationDoubleSpeed * 2;

			item.Quality -= decrement;

			_qualityToBoundariesAligner.AlignQualityToBoundaries(item);
			_sellInDecrementor.DecrementSellIn(item);

		}
	}
}
