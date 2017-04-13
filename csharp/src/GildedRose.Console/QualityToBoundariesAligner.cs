using GildedRose.Console.Contract;

namespace GildedRose.Console
{
	public class QualityToBoundariesAligner : IQualityToBoundariesAligner
	{
		public static int MinQuality = 0;
		public static int MaxQuality = 50;

		public void AlignQualityToBoundaries(Item item)
		{
			item.Quality = item.Quality < MinQuality
				? 0
				: item.Quality > MaxQuality
					? 50
					: item.Quality;
		}
	}
}
