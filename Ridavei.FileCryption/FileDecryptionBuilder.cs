using System;
using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    /// <summary>
    /// Builder class used for file decryption.
    /// </summary>
    public class FileDecryptionBuilder : AFileCryptionBuilderBase, IFileDecryptionBuilder
    {
        private FileDecryptionBuilder() { }

        /// <summary>
        /// Static method to create the builder.
        /// </summary>
        /// <returns>Builder</returns>
        public static FileDecryptionBuilder CreateBuilder()
        {
            return new FileDecryptionBuilder();
        }

        /// <summary>
        /// Set the method used for decryption.
        /// </summary>
        /// <param name="func"></param>
        /// <returns>Builder</returns>
        public AFileCryptionBuilderBase SetDecryptionMethod(Func<Stream, ContentType, string, Stream> func)
        {
            return this.SetCryptionMethod(func);
        }

        /// <summary>
        /// File decryption method that returns <see cref="Stream"/>.
        /// </summary>
        /// <param name="fileInfoForLoaderMethod"><see cref="Object"/> that contains basic information used by the loader method.</param>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="password">Password used for decryption.</param>
        /// <returns><see cref="Stream"/> of decrypted file.</returns>
        /// <exception cref="ArgumentNullException">Exception throwed when none of the methods are set or file info are null.</exception>
        /// <exception cref="FileNotFoundException">Exception throwed when the file was not found.</exception>
        public virtual Stream Decrypt(object fileInfoForLoaderMethod, ContentType contentType, string password)
        {
            return Cryption(fileInfoForLoaderMethod, contentType, password);
        }
    }
}