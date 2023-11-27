using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text;

namespace URLShortenerApp.Shortener
{
    public class UrlShortener : IUrlShortener
    {
        private readonly string prefix = "https://";
		private readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZWabcdefghijklmnopqrstuvwxyz0123456789";
		private readonly int maxLen = 6;
        private readonly int minLen = 4;
		private readonly Random rnd = new Random();

		public string Generate()
		{
			StringBuilder shortUrlBuilder = new StringBuilder(prefix);
			int len = rnd.Next(minLen, maxLen + 1);
			for (int i = 0; i < len; i++)
			{
				int nextIndex = rnd.Next(alphabet.Length - 1);
				shortUrlBuilder.Append(alphabet[nextIndex]);
			}

			return shortUrlBuilder.ToString();
		}
    }
}
