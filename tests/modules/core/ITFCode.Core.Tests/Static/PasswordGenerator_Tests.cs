using ITFCode.Core.Static;

namespace ITFCode.Core.Tests
{
    public class PasswordGenerator_Tests
    {
        #region Tests 

        [Theory]
        [MemberData(nameof(Data))]
        public void Generate_Password_Check_Length_Symblos(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial)
        {
            string symbols = (useLowercase ? PasswordGenerator.LOWER_CASE : string.Empty) +
                (useUppercase ? PasswordGenerator.UPPER_CASE : string.Empty) +
                (useNumbers ? PasswordGenerator.NUMBERS : string.Empty) +
                (useSpecial ? PasswordGenerator.SPECIALS : string.Empty);

            foreach (var length in Enumerable.Range(10, 100))
            {
                var pass = PasswordGenerator.Generate(
                    useLowercase: useLowercase,
                    useUppercase: useUppercase,
                    useNumbers: useNumbers,
                    useSpecial: useSpecial,
                    passwordSize: length);

                TestLengthAndSymblos(pass, length, symbols);
            }
        }

        #endregion

        #region Test Data 

        public static IEnumerable<object[]> Data
        {
            get
            {
                var values = new bool[] { false, true };

                List<object[]> compositions = new List<object[]>();

                for (int i = 0; i < values.Length; i++)
                {
                    var value0 = values[i];
                    var value1 = value0;
                    var value2 = value0;
                    var value3 = value0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 1) value1 = !value0;
                        if (j == 2) value2 = !value0;
                        if (j == 3) value3 = !value0;

                        var composition = new object[] { value0, value1, value2, value3 };
                        if (composition.Any(x => (bool)x))
                            compositions.Add(composition);
                    }
                }

                return compositions;
            }
        }

        #endregion

        #region Private Methods 

        private void TestLengthAndSymblos(string password, int length, IEnumerable<char> symbols)
        {
            Assert.Equal(length, password.Length);

            foreach (var symbol in password)
                Assert.Contains(symbol, symbols);
        }

        #endregion
    }
}
