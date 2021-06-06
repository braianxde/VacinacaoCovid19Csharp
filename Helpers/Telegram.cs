using System.IO;
using System.Net;

namespace ProjetoIntegrador4B.Helpers
{
    public class Telegram
    {
        public static string sendMessage(string text)
        {

            string url = "https://api.telegram.org/bot1762205633:AAHKJFU736phJvNThD5WL4asanKv7wwpGhc/sendMessage?chat_id=-564509160&text=" + text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
