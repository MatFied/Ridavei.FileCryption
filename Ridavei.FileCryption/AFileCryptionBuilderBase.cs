using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;

namespace Ridavei.FileCryption
{
    /// <summary>
    /// Base class used for file encryption/decryption builders.
    /// </summary>
    public abstract class AFileCryptionBuilderBase<T> where T: AFileCryptionBuilderBase<T>
    {
        /// <summary>
        /// Method used for loading file.
        /// </summary>
        private Func<object, Stream> _fileLoadMethod;

        /// <summary>
        /// Dictionary of encryption/decryption methods for desired content types.
        /// </summary>
        private readonly Dictionary<ContentType, Func<Stream, string, Stream>> _cryptionMethods = new Dictionary<ContentType, Func<Stream, string, Stream>>();

        /// <summary>
        /// Instance of the builder.
        /// </summary>
        protected abstract T BuilderInstance { get; }

        /// <summary>
        /// Hided constructor for <see cref="AFileCryptionBuilderBase{T}"/>.
        /// </summary>
        protected AFileCryptionBuilderBase() { }

        /// <summary>
        /// Sets the method used for loading file.
        /// </summary>
        /// <param name="func"></param>
        /// <returns>Builder</returns>
        public T SetFileLoaderMethod(Func<object, Stream> func)
        {
            _fileLoadMethod = func;
            return (T)this;
        }

        /// <summary>
        /// Add method used for encryption/decryption.
        /// </summary>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="func"></param>
        /// <returns>Builder</returns>
        protected AFileCryptionBuilderBase<T> AddCryptionMethod(ContentType contentType, Func<Stream, string, Stream> func)
        {
            if (_cryptionMethods.ContainsKey(contentType))
                _cryptionMethods[contentType] = func;
            else
                _cryptionMethods.Add(contentType, func);

            return this;
        }

        /// <summary>
        /// File encryption/decryption method that returns <see cref="Stream"/>.
        /// </summary>
        /// <param name="fileInfoForLoaderMethod"><see cref="Object"/> that contains basic information used by the loader method.</param>
        /// <param name="contentType">Represents the MIME Content-Type header.</param>
        /// <param name="password">Password used for encryption/decryption.</param>
        /// <returns><see cref="Stream"/> of encrypted/decrypted file.</returns>
        /// <exception cref="ArgumentNullException">Exception throwed when file load method or file info or content type are null.</exception>
        /// <exception cref="ArgumentException">Exception throwed when no cryption method exists.</exception>
        /// <exception cref="FileNotFoundException">Exception throwed when the file was not found.</exception>
        /// <exception cref="NotSupportedException">Exception throwed when the content type is not supported.</exception>
        protected virtual Stream Cryption(object fileInfoForLoaderMethod, ContentType contentType, string password)
        {
            if (_fileLoadMethod == null)
                throw new ArgumentNullException(nameof(_fileLoadMethod), "File loader method is null.");
            if (_cryptionMethods.Count == 0)
                throw new ArgumentException("No cryption methods exists.", nameof(_cryptionMethods));
            if (fileInfoForLoaderMethod == null)
                throw new ArgumentNullException(nameof(fileInfoForLoaderMethod), "File info used for file loader method is null.");
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType), "Content type is null.");

            using (Stream file = _fileLoadMethod(fileInfoForLoaderMethod))
            {
                if (file == null)
                    throw new FileNotFoundException("File doesn't exists");

                if (!_cryptionMethods.TryGetValue(contentType, out Func<Stream, string, Stream> cryptionMethod))
                    throw new NotSupportedException($"Content type \"{contentType}\" is not supported.");
                return cryptionMethod(file, password);
            }
        }
    }
}
