using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Processors;

namespace GildedRose.Console
{
    public class Inventory
    {
        public static int MinQuality = 0;
        public static int MaxQuality = 50;
        public static int MinSellin = 0;

        public IList<ItemContainer> Items;


        public Inventory()
        {
            Items = new List<ItemContainer>
            {
                new ItemContainer() { Item =  new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}, ItemProcessor = new RegularItemProcessor()},
                new ItemContainer() { Item =  new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}, ItemProcessor = new GrowingQualityItemProcessor()},
                new ItemContainer() { Item =  new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}, ItemProcessor = new RegularItemProcessor()},
                new ItemContainer() { Item =  new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}, ItemProcessor = new LegendaryItemProcessor()},
                new ItemContainer() { Item =  new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                }, ItemProcessor = new GrowingToTheLimitQualityItemProcessor()},
                new ItemContainer() { Item =  new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}, ItemProcessor = new ConjuredItemProcessor()}
            };
        }

        public Item GetItemByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name");
            }

            return Items.First(item => string.Equals(item.Item.Name, name, StringComparison.InvariantCultureIgnoreCase)).Item;
        }

        public void UpdateQuality()
        {
            foreach (var curr in Items)
            {
                curr.ItemProcessor.UpdateQuality(curr.Item);
            }
        }

        public static void AdjustQualityToAllowedBoundaries(Item item)
        {
            item.Quality = item.Quality < MinQuality
                ? 0
                : item.Quality > MaxQuality
                    ? 50
                    : item.Quality;
        }
    }
}
