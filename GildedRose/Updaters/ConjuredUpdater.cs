using System;

namespace GildedRoseKata.Updaters;

public class ConjuredUpdater : ItemUpdater
{
    public ConjuredUpdater(Item item) : base(item) { }

    public override void Update()
    {
        DecrementSellIn(); // Decrement the sell in days by 1
        AdjustQuality(Item.SellIn < 0 ? -4 : -2); // Update the quality - if past sell by date decrease by 4, otherwise by 2 (x2 as fast as other items)
    }
}