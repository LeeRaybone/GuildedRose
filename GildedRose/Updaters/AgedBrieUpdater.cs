namespace GildedRoseKata.Updaters;

public class AgedBrieUpdater : ItemUpdater
{
    public AgedBrieUpdater(Item item) : base(item) { }

    public override void Update()
    {
        DecrementSellIn(); // Decrement the sell in days by 1
        AdjustQuality(Item.SellIn < 0 ? 2 : 1); // Update the quality - if past sell by date increases by 2, otherwise by 1 (current logic)
    }
}


