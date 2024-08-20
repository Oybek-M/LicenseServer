namespace LicenseServer.Application.Common.Helper
{
    public static class LicenseKeyHelper
    {
        // Generate Unique License Key Code - Starts
        private static readonly string ValidChars = "ACEFHJKMNPRSTUVWXYZ234579";
        private static readonly Random Rnd = new Random(Guid.NewGuid().GetHashCode());

        public static string GenerateLicenseKey(this int phraseLength, int phraseCount)
        {
            return string.Join("-", Enumerable.Range(0, phraseCount)
                                              .Select(_ => GeneratePhrase(phraseLength)));
        }

        private static string GeneratePhrase(int length)
        {
            char[] phrase = new char[length];
            for (int i = 0; i < length; i++)
            {
                phrase[i] = ValidChars[Rnd.Next(ValidChars.Length)];
            }
            return new string(phrase);
        }
        // Generate Unique License Key Code - Ends
    }
}
