using UnityEngine;
using Zenject;

public class SavesProviderTester : MonoBehaviour
{
    private ISaveLoadHandler _saveLoadHandler;
    private IWallet _wallet;

    [Inject]
    private void Construct(ISaveLoadHandler saveLoadHandler, IWallet wallet)
    {
        _saveLoadHandler = saveLoadHandler;
        _wallet = wallet;
    }

    public void Save()
    {
        _wallet.AddAmountToCurrency(new Currency(){Amount = 15, CurrencyType = CurrencyType.SoftCurrency});
        _saveLoadHandler.Save();
    }

    public void Load()
    {
        var amount = _wallet.GetCurrencyAmount(CurrencyType.SoftCurrency);
        Debug.Log($"soft amount is : {amount}");
        
        _saveLoadHandler.Load();
    }
}
