using GildedRoseKata.Updaters;
using System.Collections.Generic;

namespace GildedRoseKata;

/// <summary>
/// Orchestrates the daily update of all items in the inventory.
/// Delegates update logic to the appropriate <see cref="ItemUpdater"/> 
/// for each item via <see cref="ItemUpdaterFactory"/>.
/// </summary>
public class GildedRose
{

    private readonly IList<Item> Items;

    /// <summary>
    /// Initialises a new instance of <see cref="GildedRose"/> with the given inventory.
    /// </summary>
    /// <param name="Items">The list of items to be managed.</param>
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    /// <summary>
    /// Updates the Quality and SellIn values of all items in the inventory for the current day.
    /// Each item is handled by its own updater, determined by the <see cref="ItemUpdaterFactory"/>.
    /// </summary>
    public void UpdateQuality()
    {

        foreach (var item in Items)
        {
            ItemUpdaterFactory.For(item).Update();
        }
    }
}