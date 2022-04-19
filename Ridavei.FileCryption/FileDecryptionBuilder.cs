using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    public class FileDecryptionBuilder : AFileCryptionBuilder, IFileDecryptionBuilder
    {
        private FileDecryptionBuilder() { }

        public static FileDecryptionBuilder CreateBuilder()
        {
            return new FileDecryptionBuilder();
        }

        public virtual Stream Decrypt(object fileInfoForLoaderMethod, ContentType contentType, string password)
        {
            return Cryption(fileInfoForLoaderMethod, contentType, password);
        }
    }
}