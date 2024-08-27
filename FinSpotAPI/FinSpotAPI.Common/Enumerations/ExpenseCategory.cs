using System.ComponentModel;

namespace FinSpotAPI.Common.Enumerations
{
    public enum ExpenseCategory
    {
        [Description("Payments for supplies and services")]
        PaymentsForSuppliesAndServices,
        Transfers,
        [Description("ERIP payments")]
        ERIPPayments,
        [Description("Operations in ATM/Cashier")]
        OperationsInATM,
        [Description("Currency exchange")]
        CurrencyExchange,
        [Description("Transfers by cards")]
        TransfersByCards,
        Fee,
        Other,
    }
}
