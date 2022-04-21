using System;
using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    /// <summary>
    /// Builder class used for file decryption.
    /// </summary>
    public class FileDecryptionBuilder : AFileCryptionBuilderBase<FileDecryptionBuilder>, IFileDecryptionBuilder
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
        /// Instance of the builder.
        /// </summary>
        protected override FileDecryptionBuilder BuilderInstance => this;

        /// <summary>
        /// Add method used for decryption.
        /// </summary>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="func"></param>
        /// <returns>Builder</returns>
        public FileDecryptionBuilder AddDecryptionMethod(ContentType contentType, Func<Stream, string, Stream> func)
        {
            AddCryptionMethod(contentType, func);
            return this;
        }

        /// <summary>
        /// File decryption method that returns <see cref="Stream"/>.
        /// </summary>
        /// <param name="fileInfoForLoaderMethod"><see cref="Object"/> that contains basic information used by the loader method.</param>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="password">Password used for decryption.</param>
        /// <returns><see cref="Stream"/> of decrypted file.</returns>
        /// <exception cref="ArgumentNullException">Exception throwed when file load method or file info or content type are null.</exception>
        /// <exception cref="ArgumentException">Exception throwed when no cryption method exists.</exception>
        /// <exception cref="FileNotFoundException">Exception throwed when the file was not found.</exception>
        /// <exception cref="NotSupportedException">Exception throwed when the content type is not supported.</exception>
        public virtual Stream Decrypt(object fileInfoForLoaderMethod, ContentType contentType, string password)
        {
            return Cryption(fileInfoForLoaderMethod, contentType, password);
        }
    }
}