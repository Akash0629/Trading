using System.ComponentModel;

namespace Trading.Domain.Enums
{
    public enum TradingType
    {
        [Description("Buy")]
        Buy = 1,
        [Description("Sell")]
        Sell = 2
    }
}
