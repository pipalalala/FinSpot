using System.ComponentModel;

namespace FinSpotAPI.Common.Helpers
{
    public static class EnumHelpers
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            return attributes.Any()
                ? attributes.First().Description
                : value.ToString();
        }
    }
}
