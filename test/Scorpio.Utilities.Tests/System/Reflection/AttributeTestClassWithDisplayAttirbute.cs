using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace System.Reflection
{
    [Serializable]
    internal class AttributeTestClassWithDisplayAttirbute
    {
        [DisplayName("UserName")]
        [Description("User's name")]
        public string Name { get; set; }
        public string Value { get; set; }

        [Display(Name = "Display UserName", Description = "User's display name")]
        public string DisplayName { get; set; }

    }
}