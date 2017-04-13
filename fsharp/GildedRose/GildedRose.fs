module GildedRose

open System.Collections.Generic

type Item = { Name: string; SellIn: int; Quality: int }

type GildedRose(items:IList<Item>) as this =
    let Items = items
    let maxQuality = 50
    let minQuality = 0
    let normalQualityChangeSpeed = 1

    member this.dispatch(item:Item byref) =
        match item.Name with
        | "Aged Brie" -> this.agedBrieFlow(&item)
        | "Sulfuras, Hand of Ragnaros" -> this.sulfurasFlow(&item)
        | "Backstage passes to a TAFKAL80ETC concert" -> this.backstageFlow(&item)
        | "Conjured Mana Cake" -> this.conjuredFlow(&item)
        | _ -> this.regularFlow(&item)

    member this.regularFlow(item:Item byref) =
        this.decrementSellIn(&item)
        this.decreaseBy(&item, this.getQualityChangeSpeed(&item))

    member this.backstageFlow(item:Item byref) =
        this.decrementSellIn(&item)
        let speed = this.getBackStageQualityChangeSpeed(item.SellIn)
        if speed = 0 then
            this.reset(&item)
        else
            this.increaseBy(&item, speed)

    member this.conjuredFlow(item:Item byref) =
        this.decrementSellIn(&item)
        this.decreaseBy(&item, this.getQualityChangeSpeed(&item) * 2)

    member this.sulfurasFlow(item:Item byref) =
        ()

    member this.agedBrieFlow(item:Item byref) =
        this.decrementSellIn(&item)
        this.increaseBy(&item, this.getQualityChangeSpeed(&item))

    member this.getQualityChangeSpeed(item:Item byref) =
        if item.SellIn < 0 then
            normalQualityChangeSpeed * 2
        else 
            normalQualityChangeSpeed

    member this.getBackStageQualityChangeSpeed(sellin) =
        match sellin with
        | sellin when sellin > 10 -> 1
        | sellin when sellin < 11 && sellin > 5 -> 2
        | sellin when sellin < 6 && sellin > 0 -> 3
        | _ -> 0

    member this.increaseBy(item:Item byref, amount:int) =
        if item.Quality < maxQuality then
            item <- { item with Quality = (item.Quality + amount) }

    member this.decreaseBy(item:Item byref, amount:int) =
        if item.Quality > minQuality then
            item <- { item with Quality = (item.Quality - amount) }

    member this.reset(item:Item byref) =
        item <- { item with Quality = 0 }

    member this.decrementSellIn(item:Item byref) =
        item <- { item with SellIn = (item.SellIn - 1) }

    member this.UpdateQuality() =
        for i = 0 to Items.Count - 1 do
            let mutable item = Items.[i]
            this.dispatch(&item)
            Items.[i] <- item
        ()

[<EntryPoint>]
let main argv = 
    printfn "OMGHAI!"
    let Items = new List<Item>()
    Items.Add({Name = "+5 Dexterity Vest"; SellIn = 10; Quality = 20})
    Items.Add({Name = "Aged Brie"; SellIn = 2; Quality = 0})
    Items.Add({Name = "Elixir of the Mongoose"; SellIn = 5; Quality = 7})
    Items.Add({Name = "Sulfuras, Hand of Ragnaros"; SellIn = 0; Quality = 80})
    Items.Add({Name = "Sulfuras, Hand of Ragnaros"; SellIn = -1; Quality = 80})
    Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 15; Quality = 20})
    Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 10; Quality = 49})
    Items.Add({Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 5; Quality = 49})
    Items.Add({Name = "Conjured Mana Cake"; SellIn = 3; Quality = 6})

    let app = new GildedRose(Items)
    for i = 0 to 30 do
        printfn "-------- day %d --------" i
        printfn "name, sellIn, quality"
        for j = 0 to Items.Count - 1 do
             printfn "%s, %d, %d" Items.[j].Name Items.[j].SellIn Items.[j].Quality
        printfn ""
        app.UpdateQuality()
    System.Console.ReadKey() |> ignore
    0 