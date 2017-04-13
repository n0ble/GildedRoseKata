using GildedRose.Console.Contract;

namespace GildedRose.Console.Processors
{
	public class LegendaryItemProcessor : IItemChangable
	{
		public void UpdateSellInAndQuality(Item item)
		{
			// legendary item never has to be sold or decreases in Quality
		}
	}
}
