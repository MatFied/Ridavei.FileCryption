using System;
using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    /// <summary>
    /// Interface for all file decryption builders.
    /// </summary>
    public interface IFileDecryptionBuilder
    {
        /// <summary>
        /// File decryption method that returns <see cref="Stream"/>.
        /// </summary>
        /// <param name="fileInfoForLoaderMethod"><see cref="Object"/> that contains basic information used by the loader method.</param>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="password">Password used for decryption.</param>
        /// <returns><see cref="Stream"/> of decrypted file.</returns>
        Stream Decrypt(object fileInfoForLoaderMethod, ContentType contentType, string password);
    }
}
