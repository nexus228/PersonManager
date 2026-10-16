using System.Text.RegularExpressions;

namespace PersonManager_WPF_CLIENT.Utils
{
    internal static class PersonDataValidator
    {
        public static bool IsPhoneNumberValid(string phoneNumber)
        { 
            bool isValid = false;

            string pattern = @"^\+?[0-9]*$";
            isValid = Regex.IsMatch(phoneNumber, pattern);


            return isValid;

        }

        public static bool IsZipCodeValid(string zipCode)
        {
            bool isValid = false;

            string pattern = @"^[0-9]+$";

            if (Regex.IsMatch(zipCode, pattern))
            {
                if(zipCode.Length == 5)
                    isValid = true;
            }

            return isValid;
        }
    }
}
