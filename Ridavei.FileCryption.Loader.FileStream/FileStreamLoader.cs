using System;
using System.IO;
using System.Security;

namespace Ridavei.FileCryption.Loader.FileStream
{
    /// <summary>
    /// Static class for extending the <see cref="AFileCryptionBuilderBase"/>.
    /// </summary>
    public static class FileStreamLoader
    {
        /// <summary>
        /// Extension method that uses <see cref="System.IO.FileStream"/> as file loader method.
        /// </summary>
        /// <param name="builder">Builder for file encryption/decryption.</param>
        /// <param name="fileMode">Enum used to determine how to open or create the file.</param>
        /// <param name="fileAccess">Enum used to determine how the file can be accessed.</param>
        /// <param name="fileShare">Enum used to determine how the file will be shared by processes.</param>
        /// <returns>Builder</returns>
        public static AFileCryptionBuilderBase UseFileStreamLoader(this AFileCryptionBuilderBase builder, FileMode fileMode = FileMode.Open, FileAccess fileAccess = FileAccess.Read, FileShare fileShare = FileShare.Read)
        {
            builder.SetFileLoaderMethod((object filePath) =>
            {
                return LoadFile(filePath.ToString(), fileMode, fileAccess, fileShare);
            });

            return builder;
        }

        /// <summary>
        /// Method that retrieves a <see cref="System.IO.FileStream"/> for the indicated path.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <param name="fileMode">Enum used to determine how to open or create the file.</param>
        /// <param name="fileAccess">Enum used to determine how the file can be accessed.</param>
        /// <param name="fileShare">Enum used to determine how the file will be shared by processes.</param>
        /// <returns>Opened file</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="SecurityException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static Stream LoadFile(string filePath, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
        {
            return new System.IO.FileStream(filePath, fileMode, fileAccess, fileShare);
        }
    }
}