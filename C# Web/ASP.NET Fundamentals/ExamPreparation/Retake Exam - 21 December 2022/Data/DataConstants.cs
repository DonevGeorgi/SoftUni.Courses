namespace Contacts.Data
{
    public static class DataConstants
    {
        //Contact constants
        public const int FirstNameMaxLength = 50;
        public const int FirstNameMinLength = 2;

        public const int LastNameMaxLength = 50;
        public const int LastNameMinLength = 5;

        public const int EmailMaxLength = 60;
        public const int EmailMinLength = 10;

        public const int PhoneNumberMaxLength = 13;
        public const int PhoneNumberMinLength = 10;
        public const string RegularExpresionForPhone = @"^(?:\\d{1}|\\+359)(?:\\ |\\-)\\d{3}(?:\\ |\\-)\\d{2}(?:\\ |\\-)\\d{2}(?:\\ |\\-)\\d{2}$";

        public const string WebsiteRegularExpresion = @"^(www.)(?:[A-za-z0-9\-]+)(.bg)$";
    }
}
