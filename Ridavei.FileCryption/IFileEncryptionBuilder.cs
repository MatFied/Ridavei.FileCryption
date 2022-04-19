using System;
using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    /// <summary>
    /// Interface for all file encryption builders.
    /// </summary>
    public interface IFileEncryptionBuilder
    {
        /// <summary>
        /// File encryption method that returns <see cref="Stream"/>.
        /// </summary>
        /// <param name="fileInfoForLoaderMethod"><see cref="Object"/> that contains basic information used by the loader method.</param>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="password">Password used for encryption.</param>
        /// <returns><see cref="Stream"/> of encrypted file.</returns>
        Stream Encrypt(object fileInfoForLoaderMethod, ContentType contentType, string password);
    }
}
