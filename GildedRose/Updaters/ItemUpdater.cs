using System;

namespace GildedRoseKata.Updaters;

/// <summary>
/// Abstract base class for all item updaters.
/// Each item type has its own concrete implementation responsible 
/// for defining how that item's quality and sell-in value change each day.
/// </summary>
public abstract class ItemUpdater
{    
    /// <summary>
    /// The item being managed by this updater.
    /// Protected so subclasses can access it, readonly so it cannot be reassigned.
    /// </summary>
    protected readonly Item Item;

    /// <summary>
    /// Initialises a new instance of <see cref="ItemUpdater"/> with the given item.
    /// </summary>
    /// <param name="item">The item to be updated each day.</param>
    protected ItemUpdater(Item item) => Item = item;

    /// <summary>
    /// Applies the daily update logic for this item type.
    /// Must be implemented by each concrete updater class.
    /// </summary>
    public abstract void Update();

    /// <summary>
    /// Decrements the item's SellIn value by 1.
    /// Shared helper to avoid repetition across subclasses.
    /// </summary>
    protected void DecrementSellIn() => Item.SellIn--;

    /// <summary>
    /// Adjusts the item's Quality by the given amount, clamped between 0 and 40.
    /// Pass a positive integer to increase quality, negative to decrease.
    /// </summary>
    /// <param name="amount">The amount to adjust quality by. Can be positive or negative.</param>
    protected void AdjustQuality(int amount) =>
        Item.Quality = Math.Clamp(Item.Quality + amount, 0, 40);
}
