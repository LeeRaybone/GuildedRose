using System;

namespace GildedRoseKata.Updaters;

public class NormalItemUpdater : ItemUpdater
{
    public NormalItemUpdater(Item item) : base(item) { }

    public override void Update()
    {
        DecrementSellIn(); // Decrement the sell in days by 1
        AdjustQuality(Item.SellIn < 0 ? -2 : -1); // Update the quality - if past selll by date decrease by 2, otherwise by 1
    }
}
