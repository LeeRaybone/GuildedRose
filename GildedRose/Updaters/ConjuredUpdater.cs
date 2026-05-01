using System;

namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater for Conjured items.
/// Conjured items degrade in quality twice as fast as normal items,
/// and four times as fast once the sell by date has passed.
/// </summary>
public class ConjuredUpdater : ItemUpdater
{
    /// <summary>
    /// Initialises a new instance of <see cref="ConjuredUpdater"/> with the given item.
    /// </summary>
    /// <param name="item">The Conjured item to be updated.</param>
    public ConjuredUpdater(Item item) : base(item) { }

    /// <summary>
    /// Decrements SellIn by 1, then decreases Quality by 2 before the sell by date,
    /// or by 4 once the sell by date has passed.
    /// Quality is clamped to a minimum of 0.
    /// </summary>
    public override void Update()
    {
        DecrementSellIn();
        AdjustQuality(Item.SellIn < 0 ? -4 : -2);
    }
}