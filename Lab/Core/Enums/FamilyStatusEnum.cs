using Lab.Resources;
using System.ComponentModel;

namespace Lab.Core.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FamilyStatusEnum
    {
        [LocalizedDescription("None", typeof(EnumsResources))]
        None,
        [LocalizedDescription("Divorced", typeof(EnumsResources))]
        Divorced,
        [LocalizedDescription("Married", typeof(EnumsResources))]
        Married
    }
}
