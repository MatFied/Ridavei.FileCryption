using System.IO;

namespace Ridavei.FileCryption.Tests.Extensions
{
    internal static class FileLoaderExt
    {
        public static T UseFileLoaderExt<T>(this AFileCryptionBuilderBase<T> builder) where T : AFileCryptionBuilderBase<T>
        {
            builder.SetFileLoaderMethod((object filePath) =>
            {
                return new FileStream(filePath.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
            });
            return (T)builder;
        }
    }
}
