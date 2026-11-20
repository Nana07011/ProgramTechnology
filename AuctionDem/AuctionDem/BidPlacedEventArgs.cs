namespace AuctionDemo;

public sealed class BidPlacedEventArgs:EventArgs
{

    public string Title { get; }
    public string Bidder { get; }
    public decimal Amount { get; }
    public decimal? PreviosAmount { get; }
    public string? Previosleader { get; }
    public BidPlacedEventArgs(string title, string bidder, decimal amount, decimal? previosAmount, string? previosleader)
    {
        Title = title;
        Bidder = bidder;
        Amount = amount;
        PreviosAmount = previosAmount;
        Previosleader = previosleader;
    }

}