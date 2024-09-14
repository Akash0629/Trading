using System.ComponentModel;

namespace Trading.Domain.Enums
{
    public enum Operation
    {
        [Description("Insert")]
        Insert = 1,
        [Description("Update")]
        Update = 2,
        [Description("Cancel")]
        Cancel = 3
    }
}
