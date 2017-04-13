using GildedRose.Console.Contract;

namespace GildedRose.Console
{
	public class SellInDecrementor : ISellInDecrementor
	{
		public void DecrementSellIn(Item item)
		{
			item.SellIn--;
		}
	}
}
