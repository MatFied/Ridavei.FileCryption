using System.IO;

namespace Ridavei.FileCryption.Tests.Extensions
{
    internal static class FileLoaderExt
    {
        public static AFileCryptionBuilderBase UseFileLoaderExt(this AFileCryptionBuilderBase builder)
        {
            return builder.SetFileLoaderMethod((object filePath) =>
            {
                return new FileStream(filePath.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
            });
        }
    }
}
