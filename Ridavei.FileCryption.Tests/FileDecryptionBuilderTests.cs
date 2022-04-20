using NUnit.Framework;

namespace Ridavei.FileCryption.Tests
{
    [TestFixture]
    public class FileDecryptionBuilderTests : AFileCryptionBuilderTestsBase
    {
        [SetUp]
        public void SetUp()
        {
            Builder = FileDecryptionBuilder.CreateBuilder();
            CryptionMethod = ((FileDecryptionBuilder)Builder).Decrypt;
            SetCryptionMethod = ((FileDecryptionBuilder)Builder).SetDecryptionMethod;
        }
    }
}
