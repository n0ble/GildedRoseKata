module GildedRoseTest

open GildedRose
open System
open System.IO
open System.Text
open NUnit.Framework
open System.Collections.Generic
open ApprovalTests
open ApprovalTests.Reporters

[<TestFixture>]
type BasicTests () as this =
    [<Test>] member this.Foo ()=
        let Items = new List<Item>()  
        Items.Add({Name = "foo"; SellIn = 0; Quality = 0})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual("foo", Items.[0].Name)

    [<Test>] member this.SystemLowersQualityAfterOneDay ()=
        let Items = new List<Item>()  
        Items.Add({Name = "regular item"; SellIn = 5; Quality = 5})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(4, Items.[0].Quality)

    [<Test>] member this.SystemLowersSellInAfterOneDay ()=
        let Items = new List<Item>()  
        Items.Add({Name = "regular item"; SellIn = 5; Quality = 5})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(4, Items.[0].SellIn)

[<TestFixture>]
type BoundariesTests () as this =
    [<Test>] member this.QualityCantBeLowerThanZero ()=
        let Items = new List<Item>()  
        Items.Add({Name = "regular item"; SellIn = 1; Quality = 0})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(0, Items.[0].Quality)

    [<Test>] member this.QualityOfAgedItemCantBeLowerThanZero ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Aged Brie"; SellIn = 1; Quality = 0})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(1, Items.[0].Quality)

    [<Test>] member this.QualityOfLegendaryItemCantBeLowerThanZero ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Sulfuras, Hand of Ragnaros"; SellIn = 1; Quality = 0})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(0, Items.[0].Quality)

    [<Test>] member this.QualityOfConjuredItemCantBeLowerThanZero ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Conjured Mana Cake"; SellIn = 1; Quality = 0})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(0, Items.[0].Quality)

    [<Test>] member this.QualityCantBeGreaterThanFifty ()=
        let Items = new List<Item>()  
        Items.Add({Name = "regular item"; SellIn = 5; Quality = 50})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(49, Items.[0].Quality)

    [<Test>] member this.QualityOfAgedItemCantBeGreaterThanfifty ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Aged Brie"; SellIn = 5; Quality = 50})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(50, Items.[0].Quality)

    [<Test>] member this.QualityOfBackstageItemCantBeGreaterThanfifty ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 50; Quality = 50})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(50, Items.[0].Quality)




[<TestFixture>]
type DoubleSpeedTests () as this =
    [<Test>] member this.QualityDegradesTwiceAsFastOnceTheSellByDateHasPassed ()=
        let Items = new List<Item>()  
        Items.Add({Name = "regular item"; SellIn = -1; Quality = 2})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(0, Items.[0].Quality)

    [<Test>] member this.QualityOfLegendaryItemDoesntChangeOnceTheSellByDateHasPassed ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Sulfuras, Hand of Ragnaros"; SellIn = -1; Quality = 2})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(2, Items.[0].Quality)

    [<Test>] member this.QualityOfAgedItemUpgradesTwiceAsFastOnceTheSellByDateHasPassed ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Aged Brie"; SellIn = -1; Quality = 2})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(4, Items.[0].Quality)


[<TestFixture>]
type BackStageTests () as this =
    [<Test>] member this.QualityOfBackStageItemUpgradesTwiceAsFastFor10OrLessDaysBeforeSellByDate ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 10; Quality = 2})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(4, Items.[0].Quality)

    [<Test>] member this.QualityOfBackStageItemUpgradesTripleAsFastFor5OrLessDaysBeforeSellByDate ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 5; Quality = 2})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(5, Items.[0].Quality)

    [<Test>] member this.QualityOfBackStageItemIsResetAfterSellByDate ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 5; Quality = 2})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(5, Items.[0].Quality)

[<TestFixture>]
type LegendaryItemTests () as this =
    [<Test>] member this.LegendaryItemQualityDoesntChange ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Sulfuras, Hand of Ragnaros"; SellIn = 10; Quality = 10})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(10, Items.[0].Quality)

    [<Test>] member this.LegendaryItemSellInDoesntChange ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Sulfuras, Hand of Ragnaros"; SellIn = 10; Quality = 10})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(10, Items.[0].SellIn)

[<TestFixture>]
type ConjuredItemTests () as this =
    [<Test>] member this.ConjuredItemDegradeInQualityTwiceAsFastAsNormalItems ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Conjured Mana Cake"; SellIn = 10; Quality = 10})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(8, Items.[0].Quality)

    [<Test>] member this.ConjuredItemDegradeInQualityFourthAsFastAsNormalItemsAfterSellByDate ()=
        let Items = new List<Item>()  
        Items.Add({Name = "Conjured Mana Cake"; SellIn = -10; Quality = 10})
        let app = new GildedRose(Items)
        app.UpdateQuality()
        Assert.AreEqual(6, Items.[0].Quality)


        