namespace FinSpotAPI.Common.Constants
{
    public static class ModelValidationConstants
    {
        public static class Values
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int EmailMaxLength = 150;
            public const int PasswordMaxLength = 50;
            public const int MobileNumberMaxLength = 30;
            public const int GenderNameMaxLength = 100;
            public const int Title = 50;
            public const int Details = 200;
            public static DateTime DateOfBirthMinValue => new(1990, 1, 1);
        }


        public static class ErrorMessages
        {
            public static string DateOfBirthMaxValue = $"'DateOfBirth' cannot be greater than {DateTime.UtcNow:dd-MM-yyyy}";
            public static string DateOfBirthMinValue = $"'DateOfBirth' cannot be less than {Values.DateOfBirthMinValue:dd-MM-yyyy}";
        }
    }
}
