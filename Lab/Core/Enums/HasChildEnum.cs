using Lab.Resources;
using System.ComponentModel;

namespace Lab.Core.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum HasChildEnum
    {
        [LocalizedDescription("No", typeof(EnumsResources))]
        No,
        [LocalizedDescription("Yes", typeof(EnumsResources))]
        Yes,
    }
}
