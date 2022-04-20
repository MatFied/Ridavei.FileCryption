using NUnit.Framework;

namespace Ridavei.FileCryption.Tests
{
    [TestFixture]
    public class FileEncryptionBuilderTests : AFileCryptionBuilderTestsBase
    {
        [SetUp]
        public void SetUp()
        {
            Builder = FileEncryptionBuilder.CreateBuilder();
            CryptionMethod = ((FileEncryptionBuilder)Builder).Encrypt;
            SetCryptionMethod = ((FileEncryptionBuilder)Builder).SetEncryptionMethod;
        }
    }
}