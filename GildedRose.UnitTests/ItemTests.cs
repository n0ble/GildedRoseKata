using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTests
{
    [TestClass]
    public class ItemTests
    {

        private Item GetSulfuras(Inventory inv)
        {
            return inv.GetItemByName("Sulfuras, Hand of Ragnaros");
        }
        private Item GetRegularItem(Inventory inv)
        {
            return inv.GetItemByName("+5 Dexterity Vest");
        }

        private Item GetBrieItem(Inventory inv)
        {
            return inv.GetItemByName("Aged Brie");
        }

        private Item GetBackstageItem(Inventory inv)
        {
            return inv.GetItemByName("Backstage passes to a TAFKAL80ETC concert");
        }

        private Item GetConjuredItem(Inventory inv)
        {
            return inv.GetItemByName("Conjured Mana Cake");
        }


        [TestMethod]
        public void SulfurasPermanentSellInnTest()
        {
            //arrange
            var inv = new Inventory();

            //act
            for (int i = 0; i < 100; i++)
            {
                inv.UpdateQuality();
            }
            var sulfuras = GetSulfuras(inv);

            //asert
            Assert.AreEqual(0, sulfuras.SellIn);
        }

        [TestMethod]
        public void SulfurasPermanentQualityTest()
        {
            //arrange
            var inv = new Inventory();

            //act
            for (int i = 0; i < 100; i++)
            {
                inv.UpdateQuality();
            }
            var sulfuras = GetSulfuras(inv);

            //asert
            Assert.AreEqual(80, sulfuras.Quality);
        }


        [TestMethod]
        public void SellinDecreasePositiveTest()
        {
            //arrange
            var inv = new Inventory();

            //act
            inv.UpdateQuality();
            var item = GetRegularItem(inv);

            //asert
            Assert.AreEqual(9, item.SellIn);
        }

        [TestMethod]
        public void QualityDecreasePositiveTest()
        {
            //arrange
            var inv = new Inventory();

            //act
            inv.UpdateQuality();
            var item = GetRegularItem(inv);

            //asert
            Assert.AreEqual(19, item.Quality);
        }

        //Once the sell by date has passed, Quality degrades twice as fast
        [TestMethod]
        public void QualityDoubleDecreaseTest()
        {
            //arrange
            var inv = new Inventory();

            //act
            for (int i = 0; i < 11; i++)
            {
                inv.UpdateQuality();
            }
            var item = GetRegularItem(inv);

            //asert
            Assert.AreEqual(8, item.Quality);
        }

        [TestMethod]
        public void BrieQualityIncreaseTest()
        {
            //arrange
            var inv = new Inventory();
            var days = 2;
            //act
            for (int i = 0; i < days; i++)
            {
                inv.UpdateQuality();
            }
            var item = GetBrieItem(inv);

            //asert
            Assert.AreEqual(2, item.Quality);
        }

        [TestMethod]
        public void BrieQualityDoubleIncreaseTest()
        {
            //arrange
            var inv = new Inventory();
            var days = 15;
            //act
            for (int i = 0; i < days; i++)
            {
                inv.UpdateQuality();
            }
            var item = GetBrieItem(inv);

            //asert
            Assert.AreEqual(28, item.Quality);
        }

        [TestMethod]
        public void BrieMaxQualityTest()
        {
            //arrange
            var inv = new Inventory();
            var days = 100;
            //act
            for (int i = 0; i < days; i++)
            {
                inv.UpdateQuality();
            }
            var item = GetBrieItem(inv);

            //asert
            Assert.AreEqual(50, item.Quality);
        }

        [TestMethod]
        public void BackstageLessTenDaysTest()
        {
            //arrange
            var inv = new Inventory();
            var days = 6;
            //act
            for (int i = 0; i < days; i++)
            {
                inv.UpdateQuality();
            }
            var item = GetBackstageItem(inv);

            //asert
            Assert.AreEqual(27, item.Quality);
        }

        [TestMethod]
        public void BackstageLessFiveDaysTest()
        {
            //arrange
            var inv = new Inventory();
            var days = 11;
            //act
            for (int i = 0; i < days; i++)
            {
                inv.UpdateQuality();
            }
            var item = GetBackstageItem(inv);

            //asert
            Assert.AreEqual(38, item.Quality);
        }

        [TestMethod]
        public void BackstageLostQualityTest()
        {
            //arrange
            var inv = new Inventory();
            var days = 100;
            //act
            for (int i = 0; i < days; i++)
            {
                inv.UpdateQuality();
            }
            var item = GetBackstageItem(inv);

            //asert
            Assert.AreEqual(0, item.Quality);
        }


        [TestMethod]
        public void QualityConjuredSimpleTest()
        {
            //arrange
            var inv = new Inventory();

            //act
            inv.UpdateQuality();
            var item = GetConjuredItem(inv);

            //asert
            Assert.AreEqual(4, item.Quality);
        }

        [TestMethod]
        public void QualityConjuredDoubleSpeedTest()
        {
            //arrange
            var inv = new Inventory();

            //act
            var days = 4;
            for (int i = 0; i < days; i++)
            {
                inv.UpdateQuality();
            }
            var item = GetConjuredItem(inv);

            //asert
            Assert.AreEqual(0, item.Quality);
        }
    }
}
