namespace MathPreparationApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Question
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 2000;

            public const int OptionMaxLength = 100;

            public const string PointsMinValue = "1";
            public const string PointsMaxValue = "20";

            public const int SolutionMinLength = 5;
            public const int SolutionMaxLength = 5000;
        }
        public static class Subject
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 300;
        }

        public static class Topic
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 300;
        }

        public static class User
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;
        }
    }
}
