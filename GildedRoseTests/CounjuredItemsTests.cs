using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class CounjuredItemsTests
{
    private GildedRose BuildApp(params Item[] items) => new GildedRose(new List<Item>(items));


    [Fact]
    public void SellInDecreasesByOne()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(4, item.SellIn);
    }   
    
    //TODO: To be implmented will fail until then
    [Fact]
    public void QualityDegradesByTwo_BeforeSellByDate()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(8, item.Quality);
    }

    //TODO: To be implmented will fail until then
    [Fact]
    public void QualityDegradesByFour_AfterSellByDate()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(6, item.Quality);
    }

    [Fact]
    public void QualityNeverGoesBelowZero()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 1 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(0, item.Quality);
    }
}

