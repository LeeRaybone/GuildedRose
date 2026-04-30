using System;

namespace GildedRoseKata.Updaters;

public abstract class ItemUpdater
{
    protected readonly Item Item; // protected so it can be access, but read only so cant be reassigned

    protected ItemUpdater(Item item) => Item = item;

    public abstract void Update(); // forces individual update logic to need to be implemented

    protected void DecrementSellIn() => Item.SellIn--; // shared helper -- DRY

    protected void AdjustQuality(int amount) => // pass a positive int to increase and negaative to decrease
        Item.Quality = Math.Clamp(Item.Quality + amount, 0, 50); 
}
