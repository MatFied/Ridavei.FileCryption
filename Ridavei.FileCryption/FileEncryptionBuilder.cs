using System;
using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    /// <summary>
    /// Builder class used for file encryption.
    /// </summary>
    public class FileEncryptionBuilder : AFileCryptionBuilderBase<FileEncryptionBuilder>, IFileEncryptionBuilder
    {
        private FileEncryptionBuilder() { }

        /// <summary>
        /// Static method to create the builder.
        /// </summary>
        /// <returns>Builder</returns>
        public static FileEncryptionBuilder CreateBuilder()
        {
            return new FileEncryptionBuilder();
        }

        /// <summary>
        /// Instance of the builder.
        /// </summary>
        protected override FileEncryptionBuilder BuilderInstance => this;

        /// <summary>
        /// Set the method used for encryption.
        /// </summary>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="func"></param>
        /// <returns>Builder</returns>
        public FileEncryptionBuilder AddEncryptionMethod(ContentType contentType, Func<Stream, string, Stream> func)
        {
            AddCryptionMethod(contentType, func);
            return this;
        }

        /// <summary>
        /// File encryption method that returns <see cref="Stream"/>.
        /// </summary>
        /// <param name="fileInfoForLoaderMethod"><see cref="Object"/> that contains basic information used by the loader method.</param>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="password">Password used for encryption.</param>
        /// <returns><see cref="Stream"/> of encrypted file.</returns>
        /// <exception cref="ArgumentNullException">Exception throwed when file load method or file info or content type are null.</exception>
        /// <exception cref="ArgumentException">Exception throwed when no cryption method exists.</exception>
        /// <exception cref="FileNotFoundException">Exception throwed when the file was not found.</exception>
        /// <exception cref="NotSupportedException">Exception throwed when the content type is not supported.</exception>
        public virtual Stream Encrypt(object fileInfoForLoaderMethod, ContentType contentType, string password)
        {
            return Cryption(fileInfoForLoaderMethod, contentType, password);
        }
    }
}
