using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    public class FileEncryptionBuilder : AFileCryptionBuilder, IFileEncryptionBuilder
    {
        private FileEncryptionBuilder() { }

        public static FileEncryptionBuilder CreateBuilder()
        {
            return new FileEncryptionBuilder();
        }

        public virtual Stream Encrypt(object fileInfoForLoaderMethod, ContentType contentType, string password)
        {
            return Cryption(fileInfoForLoaderMethod, contentType, password);
        }
    }
}
