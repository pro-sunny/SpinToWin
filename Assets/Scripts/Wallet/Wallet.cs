using System.Collections.Generic;
using System.Linq;

public interface IWallet
{
    public int GetCurrencyAmount(CurrencyType currencyType);
    public void AddAmountToCurrency(Currency currency);
}

public class Wallet : SaveableComponent<WalletData>, IWallet
{
    public override void PrepareSave()
    {
        _data = new WalletData()
        {
            Currencies = new List<Currency>()
        };
    }

    public override ISaveableData Serialize()
    {
        return _data;
    }

    public override void Deserialize(ISaveableData data)
    {
        if (data is WalletData walletData)
        {
            _data = walletData;
        }
    }
    
    public int GetCurrencyAmount(CurrencyType currencyType)
    {
        var currency = _data.Currencies.FirstOrDefault(c => c.CurrencyType == currencyType);
        return currency == null ? 0 : currency.Amount;
    }
    
    public void AddAmountToCurrency(Currency currency)
    {
        var localCurrency = _data.Currencies.FirstOrDefault(c => c.CurrencyType == currency.CurrencyType);
        if (localCurrency == null)
        {
            _data.Currencies.Add(currency);
        }
        else
        {
            localCurrency.Amount += currency.Amount;
        }
    }
}

public class WalletData : ISaveableData
{
    public List<Currency> Currencies;
}