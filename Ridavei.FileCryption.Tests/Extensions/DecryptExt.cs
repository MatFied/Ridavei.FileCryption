using System;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace Ridavei.FileCryption.Tests.Extensions
{
    internal static class DecryptExt
    {
        public static FileDecryptionBuilder UseDecryptTxtExt(this FileDecryptionBuilder builder)
        {
            return builder.AddDecryptionMethod(new ContentType(MediaTypeNames.Text.Plain), DecryptTxt);
        }

        private static Stream DecryptTxt(Stream file, string password)
        {
            string decryptedString = DecryptString(TestHelper.ReadTextFromFile(file), password);

            MemoryStream ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(decryptedString);
            sw.Flush();
            ms.Position = 0;
            return ms;
        }
        private static string DecryptString(string stringToEncrypt, string key)
        {
            string res = string.Empty;
            for (int i = 0; i < stringToEncrypt.Length; i++)
            {
                if (i + 1 < stringToEncrypt.Length)
                {
                    res += stringToEncrypt[i + 1].ToString() + stringToEncrypt[i].ToString();
                    i++;
                }
                else
                    res += stringToEncrypt[i].ToString();
            }
            return res;
        }
    }
}
