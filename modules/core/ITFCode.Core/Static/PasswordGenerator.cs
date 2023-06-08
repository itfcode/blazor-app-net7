namespace ITFCode.Core.Static
{
    public static class PasswordGenerator
    {
        #region Consts

        public const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        public const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string NUMBERS = "1234567890";
        public const string SPECIALS = @"!@#$%^&*()_-+=";

        #endregion

        #region Public Methods 

        public static string Generate(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
            int passwordSize)
        {
            string charSet = string.Empty;

            if (useLowercase) charSet += LOWER_CASE;
            if (useUppercase) charSet += UPPER_CASE;
            if (useNumbers) charSet += NUMBERS;
            if (useSpecial) charSet += SPECIALS;

            if (charSet.Equals(string.Empty))
                throw new Exception("Char Set Not Defined");

            var pass = string.Empty;
            int counter;
            var random = new Random();

            while (!CheckPasswordStrength(pass, useLowercase, useUppercase, useNumbers, useSpecial, passwordSize))
            {
                char[] password = new char[passwordSize];

                for (counter = 0; counter < passwordSize; counter++)
                {
                    password[counter] = charSet[random.Next(charSet.Length - 1)];
                }
                pass = string.Join(null, password);
            }

            return pass;
        }

        #endregion

        #region Private Methods 

        private static bool CheckPasswordStrength(string password, bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial, int passwordSize)
        {
            if (password == null) return false;

            if (password.Length != passwordSize) return false;

            var passed = true;

            if (useLowercase)
                passed = passed && LOWER_CASE.Intersect(password).Any();

            if (useUppercase)
                passed = passed && UPPER_CASE.Intersect(password).Any();

            if (useNumbers)
                passed = passed && NUMBERS.Intersect(password).Any();

            if (useSpecial)
                passed = passed && SPECIALS.Intersect(password).Any();

            return passed;
        }

        #endregion
    }
}