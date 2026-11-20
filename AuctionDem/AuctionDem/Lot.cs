namespace AuctionDemo;

public class Lot
{
    public Guid Id { get; } // Уникальный идентификатор, GUID - 132 бита, new GUID
    public string Title { get; } // Название
    public decimal StartPrice { get; } // Стартовая цена
    public decimal BidStep { get; } // Шаг ставки
    public decimal? CurrentBid { get; private set; } = default; // Текущая ставка
    public string? CurrentLeader { get; private set; } = default; // Текущий лидер

    public decimal? BuyNowPrice { get; } // Цена мгновенного выкупа
    public DateTime EndsAt { get; } // Время завершения торгов

    //public Action<string, decimal>? BidPlaced; //

    //public Action<string, decimal>? Repurchase; // 
    public event EventHandler<BidPlacedEventArgs>? BidPlaced;
    public event EventHandler<BuyNowTriggerEventArgs>? BuyNowTrigger;

    public Lot(string title, decimal startPrice, decimal bidStep,
        DateTime endsAt, decimal? buyNowPrice = default)
    {
        Id = Guid.NewGuid();
        Title = title;
        StartPrice = startPrice;
        BidStep = bidStep;
        EndsAt = endsAt;
        BuyNowPrice = buyNowPrice;
    }

    public void BuyNow(string buyer)
    {
        //	фиксирует продажу(можно просто вывести в консоль «лот выкуплен» и запомнить победителя);
        //	оповещает подписчиков — но вот вопрос: через BidPlaced? Или нужен новый делегат? Реши сам и напиши, почему выбрал так.
        if (BuyNowPrice is null || EndsAt < DateTime.UtcNow)
            throw new InvalidOperationException("Вы не можете выкупить этот лот");

        if (CurrentBid is null || CurrentBid < BuyNowPrice)
        {
            CurrentBid = BuyNowPrice;
            CurrentLeader = buyer;
            OnBidNowTriggered(new BuyNowTriggerEventArgs(CurrentLeader, CurrentBid.Value));
        }


    }

    protected virtual void OnBidNowTriggered(BuyNowTriggerEventArgs buyNowTriggerEventArgs)
    {
        BuyNowTrigger?.Invoke(this, buyNowTriggerEventArgs);
    }

    public void PlaceBid(string bidder, decimal amount)
    {
        if (DateTime.UtcNow >= EndsAt)
            throw new InvalidOperationException("Торги уже завершены");

        if (CurrentBid is null && amount < StartPrice)
            throw new InvalidOperationException("Ставка слишком мала");

        if (CurrentBid is not null && amount < CurrentBid + BidStep)
            throw new InvalidOperationException("Ставка слишком мала");

        var previosBid = CurrentBid;
        var previosLeader = CurrentLeader;

        CurrentBid = amount;
        CurrentLeader = bidder;

        OnBidPlaced(new BidPlacedEventArgs(Title, CurrentLeader, CurrentBid.Value, previosBid, previosLeader));
    }

    protected virtual void OnBidPlaced(BidPlacedEventArgs bidPlacedEventArgs)
    {
        BidPlaced?.Invoke(this, bidPlacedEventArgs);
    }
}