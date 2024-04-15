using System.ComponentModel.DataAnnotations;

namespace System.Reflection
{
    internal enum TestEnum
    {
        Normal,
        [Display(Name ="Display Enum",Description ="enum's display description")]
        CustomDisplay
    }
}