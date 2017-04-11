namespace GildedRose.Console
{
    class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var inv = new Inventory();
            inv.UpdateQuality();

            System.Console.ReadKey();
        }
    }
}
