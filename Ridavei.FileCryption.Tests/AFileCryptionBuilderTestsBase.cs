using System;
using System.IO;
using System.Net.Mime;

using Ridavei.FileCryption.Tests.Extensions;

using NUnit.Framework;

namespace Ridavei.FileCryption.Tests
{
    [TestFixture]
    public abstract class AFileCryptionBuilderTestsBase<T> where T : AFileCryptionBuilderBase<T>
    {
        protected Func<object, ContentType, string, Stream> CryptionMethod;
        protected Func<ContentType, Func<Stream, string, Stream>, AFileCryptionBuilderBase<T>> AddCryptionMethod;
        protected Func<AFileCryptionBuilderBase<T>> ExtensionCryptionMethod;
        protected AFileCryptionBuilderBase<T> Builder;
        protected string TestFilePath;
        protected string ExpectedExtensionCryptionFileValue;

        [Test]
        public void SetFileLoaderMethod_NullMethod__RaisesException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Builder.SetFileLoaderMethod(null);
            });
        }

        [Test]
        public void AddCryptionMethod_NullContentType__RaisesException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Builder.SetFileLoaderMethod(TestNullFileLoadMethod);
                AddCryptionMethod(null, TestCryptionMethod);
            });
        }

        [Test]
        public void AddCryptionMethod_NullCrptionMethod__RaisesException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Builder.SetFileLoaderMethod(TestNullFileLoadMethod);
                AddCryptionMethod(new ContentType(MediaTypeNames.Text.Plain), null);
            });
        }

        [Test]
        public void Cryption_NoFileLoadMethodSet__RaisesException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                CryptionMethod(string.Empty, null, string.Empty);
            });
        }

        [Test]
        public void Cryption_NoCryptionMethodAdded__RaisesException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Builder.SetFileLoaderMethod(TestFileLoadMethod);
                CryptionMethod(string.Empty, null, string.Empty);
            });
        }

        [Test]
        public void Cryption_NullFileInfo__RaisesException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Builder.SetFileLoaderMethod(TestNullFileLoadMethod);
                AddCryptionMethod(new ContentType(MediaTypeNames.Text.Plain), TestCryptionMethod);
                CryptionMethod(null, null, string.Empty);
            });
        }

        [Test]
        public void Cryption_NullContentType__RaisesException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Builder.SetFileLoaderMethod(TestNullFileLoadMethod);
                AddCryptionMethod(new ContentType(MediaTypeNames.Text.Plain), TestCryptionMethod);
                CryptionMethod("test", null, string.Empty);
            });
        }

        [Test]
        public void Cryption_FileLoadMethodReturnsNull__RaisesException()
        {
            Assert.Throws<FileNotFoundException>(() =>
            {
                ContentType ct = new ContentType(MediaTypeNames.Text.Plain);
                Builder.SetFileLoaderMethod(TestNullFileLoadMethod);
                AddCryptionMethod(ct, TestCryptionMethod);
                CryptionMethod("test", ct, string.Empty);
            });
        }

        [Test]
        public void Cryption_NotSupportedContentType__RaisesException()
        {
            Assert.Throws<NotSupportedException>(() =>
            {
                Builder.SetFileLoaderMethod(TestFileLoadMethod);
                AddCryptionMethod(new ContentType(MediaTypeNames.Text.Plain), TestCryptionMethod);
                CryptionMethod("test", new ContentType(MediaTypeNames.Text.Html), string.Empty);
            });
        }

        [Test]
        public void Cryption__ReturnsStream()
        {
            Assert.DoesNotThrow(() =>
            {
                ContentType ct = new ContentType(MediaTypeNames.Text.Plain);
                Builder.SetFileLoaderMethod(TestFileLoadMethod);
                AddCryptionMethod(ct, TestCryptionMethod);
                using (Stream stream = CryptionMethod("test", ct, string.Empty))
                {
                    Assert.IsNotNull(stream);
                }
            });
        }

        [Test]
        public void Cryption_UseExtensions__ReturnsStream()
        {
            Assert.DoesNotThrow(() =>
            {
                Builder.UseFileLoaderExt();
                ExtensionCryptionMethod();
                using (Stream stream = CryptionMethod(TestFilePath, new ContentType(MediaTypeNames.Text.Plain), "pass"))
                {
                    Assert.IsNotNull(stream);
                    Assert.AreEqual(ExpectedExtensionCryptionFileValue, TestHelper.ReadTextFromFile(stream));
                }
            });
        }

        private static Stream TestFileLoadMethod(object fileInfo)
        {
            return new MemoryStream();
        }

        private static Stream TestNullFileLoadMethod(object fileInfo)
        {
            return null;
        }

        private static Stream TestCryptionMethod(Stream file, string password)
        {
            return new MemoryStream();
        }
    }
}
