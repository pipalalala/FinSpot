using System.ComponentModel;

namespace FinSpotAPI.Common.Enumerations
{
    public enum Currency
    {
        [Description("US Dollar")]
        USD,
        [Description("Belarusian Ruble")]
        BYN,
        [Description("Euro")]
        EUR,
        [Description("British Pound")]
        GBP,
        [Description("Russian Ruble")]
        RUB
    }
}
