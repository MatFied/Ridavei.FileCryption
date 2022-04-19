using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    public interface IFileEncryptionBuilder
    {
        Stream Encrypt(object fileInfoForLoaderMethod, ContentType contentType, string password);
    }
}
