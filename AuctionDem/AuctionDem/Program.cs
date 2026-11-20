namespace AuctionDemo;
internal class Program
{
    static void Main()
    {
        Lot lot = new Lot("Pencil", 100m, 50m, DateTime.UtcNow.AddDays(1), 500m);
        lot.BidPlaced += (s, e) => Console.WriteLine($"[Log] Ставка: {e.Bidder} -> {e.Amount}");

        //lot.BidPlaced = null;

        //lot.BidPlaced("Fake", 10_000m);

        lot.PlaceBid("Bob", 100m);
        lot.PlaceBid("Alice", 200m);
    }
}