using GildedRose.Console.Contract;

namespace GildedRose.Console
{
	public class ItemContainer
	{
		public Item Item { get; set; }
		public IItemChangable ItemProcessor { get; set; }
	}
}
