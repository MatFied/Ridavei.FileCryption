# Ridavei.FileCryption

## What is FileCryption?

Ridavei.FileCryption is a cross-platform library created to ease file decryption/encryption.

## Examples in using FileCryption

### File decryption
```csharp
using System.IO;
using System.Net.Mime;

using Ridavei.FileCryption;

namespace TestProgram
{
    class Program
    {
        public static void Main (string[] args)
        {
            ContentType contentType;
            object fileInfo;
            string password;
            
            /*
              Setting the variables above
            */
            using (Stream decryptedFile = FileDecryptionBuilder
                .CreateBuilder()
                .SetFileLoaderMethod((object fileInfo) =>
                {
                    //Return file as Stream
                })
                .AddDecryptionMethod(
                    contentType,
                    (Stream file, string password) =>
                {
                    //Return decrypted Stream
                })
                .Decrypt(fileInfo, contentType, password))
            {
                //Saving the file
            }
        }
    }
}
```
#### Simple file decryption
```csharp
using System.IO;
using System.Net.Mime;

using Ridavei.FileCryption;

namespace TestProgram
{
    class Program
    {
        public static void Main (string[] args)
        {
            ContentType contentType;
            object fileInfo;
            string password;
            
            /*
              Setting the variables above
            */
            using (Stream decryptedFile = FileDecryptionBuilder
                .CreateBuilder()
                .SetFileLoaderMethod(FileLoaderMethod)
                .AddDecryptionMethod(contentType, DecryptionMethod)
                .Decrypt(fileInfo, contentType, password))
            {
                //Saving the file
            }
        }
        
        private static Stream FileLoaderMethod(object fileInfo)
        {
            //Return file as Stream
        }
        
        private static Stream DecryptionMethod(Stream file, string password)
        {
            //Return decrypted Stream
        }
    }
}
```

### Creating extensions
```csharp
using System.IO;
using System.Net.Mime;

using Ridavei.FileCryption;

namespace TestProgram
{
    //Extension for the base class
    public static class FileLoaderExt
    {
        public static T UseFileLoaderExt<T>(this AFileCryptionBuilderBase<T> builder) where T : AFileCryptionBuilderBase<T>
        {
            builder.SetFileLoaderMethod((object filePath) =>
            {
                return new FileStream(filePath.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
            });
            return (T)builder;
        }
    }
    
    //Extension for the FileEncryptionBuilder class
    public static class EncryptExt
    {
        public static FileEncryptionBuilder UseEncryptTxtExt(this FileEncryptionBuilder builder)
        {
            return builder.AddEncryptionMethod(new ContentType(MediaTypeNames.Text.Plain), EncryptTxt);
        }
        
        private static Stream EncryptTxt(Stream file, string password)
        {
            //Some magic
        }
    }
}
```
#### Simple file encryption using extensions from above
```csharp
using System.IO;
using System.Net.Mime;

using Ridavei.FileCryption;

namespace TestProgram
{
    class Program
    {
        public static void Main (string[] args)
        {
            ContentType contentType;
            object fileInfo;
            string password;
            
            /*
              Setting the variables above
            */
            using (Stream decryptedFile = FileEncryptionBuilder
                .CreateBuilder()
                .UseFileLoaderExt()
                .UseEncryptTxtExt()
                .Encrypt(fileInfo, contentType, password))
            {
                //Saving the file
            }
        }
    }
}
```
You can use many other encryption/decryption methods because they are added into a Dictionary. If you add a encryption/decryption method for a ContentType that already exists in the Dictionary it will overwrite the last one.
