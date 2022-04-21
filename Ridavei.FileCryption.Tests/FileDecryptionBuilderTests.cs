using System.IO;
using System.Reflection;

using Ridavei.FileCryption.Tests.Extensions;

using NUnit.Framework;

namespace Ridavei.FileCryption.Tests
{
    [TestFixture]
    public class FileDecryptionBuilderTests : AFileCryptionBuilderTestsBase<FileDecryptionBuilder>
    {
        [SetUp]
        public void SetUp()
        {
            Builder = FileDecryptionBuilder.CreateBuilder();
            CryptionMethod = ((FileDecryptionBuilder)Builder).Decrypt;
            AddCryptionMethod = ((FileDecryptionBuilder)Builder).AddDecryptionMethod;
            ExtensionCryptionMethod = ((FileDecryptionBuilder)Builder).UseDecryptTxtExt;
            TestFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DecryptFile.txt");
            ExpectedExtensionCryptionFileValue = "Test phrase";
        }
    }
}
