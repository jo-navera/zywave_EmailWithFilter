namespace ZywaveApi
{
    public static class Constants
    {
        public static List<string> CensorWords = new List<string>() {"test1", "test2"};
        public static string CensorReplace = "*****";
        public static string GenericExceptionTitle = "Internal Server Error";
        public static string GenericExceptionMessage = "Internal Server Error";
        public static string EmptyEmailFromExceptionMessage = "Email source cannot be empty";
        public static string EmptyEmailToExceptionMessage = "Email destination cannot be empty";
        public static string EmptyEmailSubjectExceptionMessage = "Email subject cannot be empty";
        public static string EmptyEmailBodyExceptionMessage = "Email body cannot be empty";
    }
}
