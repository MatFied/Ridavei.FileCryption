using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    public interface IFileDecryptionBuilder
    {
        Stream Decrypt(object fileInfoForLoaderMethod, ContentType contentType, string password);
    }
}
