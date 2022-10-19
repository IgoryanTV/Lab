using Lab.Resources;
using System.ComponentModel;

namespace Lab.Core.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SexEnum
    {
        [LocalizedDescription("None", typeof(EnumsResources))]
        None,
        [LocalizedDescription("Male", typeof(EnumsResources))]
        Male,
        [LocalizedDescription("Female", typeof(EnumsResources))]
        Female,
    }
}
