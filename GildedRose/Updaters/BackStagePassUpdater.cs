namespace GildedRoseKata.Updaters;

public class BackStagePassUpdater : ItemUpdater
{
    public BackStagePassUpdater(Item item) : base(item) { }

    public override void Update()
    {
        //Calculate the increase in Quality 
        var increase = Item.SellIn switch
        {
            < 3 => 4, // When 2 days or less left increse by 4
            < 8 => 3, // When 7 days or less left increse by 3
            _ => 1
        };

        DecrementSellIn(); // Decrement the sell in days by 1

        if (Item.SellIn < 0) // After concert quality defaults to 0
        {
            Item.Quality = 0;
            return;
        }

        AdjustQuality(increase);
    }
}
