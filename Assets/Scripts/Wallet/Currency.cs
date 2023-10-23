public class Currency
{
    public CurrencyType CurrencyType;
    public int Amount;
}

public enum CurrencyType
{
    SoftCurrency,
    HardCurrency,
    PremiumCurrency
}