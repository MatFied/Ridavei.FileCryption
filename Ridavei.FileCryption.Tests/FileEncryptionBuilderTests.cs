using System.IO;
using System.Reflection;

using Ridavei.FileCryption.Tests.Extensions;

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
            AddCryptionMethod = ((FileEncryptionBuilder)Builder).AddEncryptionMethod;
            ExtensionCryptionMethod = ((FileEncryptionBuilder)Builder).UseEncryptTxtExt;
            TestFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "EncryptFile.txt");
            ExpectedExtensionCryptionFileValue = "eTtsp rhsae";
        }
    }
}