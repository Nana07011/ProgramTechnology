namespace AuctionDemo;

public sealed class BuyNowTriggerEventArgs(string buyer, decimal price) : EventArgs
{
    public string Buyer { get; } = buyer;
    public decimal Price { get; } = price;
}