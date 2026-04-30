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
    
    [Fact]
    public void QualityDegradesByTwo_BeforeSellByDate()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 };
        BuildApp(item).UpdateQuality();
        Assert.Equal(8, item.Quality);
    }

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

    [Fact]
    public void QualityNeverExceedsForty()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 40 };
        BuildApp(item).UpdateQuality();
        Assert.True(item.Quality <= 40);
    }

}

