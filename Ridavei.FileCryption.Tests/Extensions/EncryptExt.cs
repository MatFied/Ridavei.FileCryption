using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption.Tests.Extensions
{
    internal static class EncryptExt
    {
        public static AFileCryptionBuilderBase UseEncryptTxtExt(this FileEncryptionBuilder builder)
        {
            return builder.AddEncryptionMethod(new ContentType(MediaTypeNames.Text.Plain), EncryptTxt);
        }

        private static Stream EncryptTxt(Stream file, string password)
        {
            string encryptedString = EncryptString(TestHelper.ReadTextFromFile(file), password);

            MemoryStream ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(encryptedString);
            sw.Flush();
            ms.Position = 0;
            return ms;
        }

        private static string EncryptString(string stringToEncrypt, string key)
        {
            string res = string.Empty;
            for (int i = 0; i < stringToEncrypt.Length; i++)
            {
                if (i + 1 < stringToEncrypt.Length)
                    res += stringToEncrypt[i + 1].ToString() + stringToEncrypt[i].ToString();
                else
                    res += stringToEncrypt[i].ToString();
            }
            return res;
        }
    }
}
