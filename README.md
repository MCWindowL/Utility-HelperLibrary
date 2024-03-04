# Utility Helper Library
****
## Overview

The Utility Helper Library is a custom library developed for .NET 6 and above by ZF.prg. It provides a collection of utility methods for common tasks related to HTTP requests, file and directory manipulation, and logging.

## Features

- **HTTP Request Handling**: Send HTTP requests and handle responses asynchronously.
- **File and Directory Operations**: Perform various operations such as downloading files, moving files/directories, creating directories, checking file/directory existence, etc.
- **Logging**: Log messages to a file with date and time information.

## Usage

### 1. Installation

To use the Utility Helper Library in your project, you can download the source code files and include them in your project manually, or you can install the library via NuGet Package Manager:

**1. Automatic Installation using dotnet add package command :**
```bash
dotnet add package Utility_HelperLibrary
```
 **2. Manual Installation :**
 
 1. Download the source code by clicking `Code > Download ZIP` or click [here.](https://github.com/MineTableWinCraft20/CLI_HelperLibrary/archive/refs/heads/main.zip)
 2. Extract the library and open your project, In your project create a folder named `lib` or any names you like.
 3. Then, In your `.csproj` file, add these two line:

```csproj
  <ItemGroup>
    <Reference Include="Utility_LibraryHelper">
      <!-- Update the HintPath based on your project path -->
      <HintPath>[Library Path]\Utility_LibraryHelper\bin\Debug\net8.0\Utility_LibraryHelper.dll</HintPath>
    </Reference>
  </ItemGroup>
  ```
    
3.a. Your `.csproj` file should look like this:
```csproj
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include="Utility_LibraryHelper">
      <!-- Update the HintPath based on your project path -->
      <HintPath>[Library Path]\Utility_LibraryHelper\bin\Debug\net8.0\Utility_LibraryHelper.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
```
  4. Then add the library using: 
  ```csharp 
using Utility_LibraryHelper;
  ```

  5. That's it! Now you can use `util.(some command)` to run any methods based on your needs and preferences.
- **If you don't understand, you can view the [source code](https://github.com/MCWindowL/Utility-HelperLibrary/blob/main/Utility-HelperLibrary/Class1.cs)**

## 2. Examples

Here are some examples demonstrating how to use the Utility Helper Library methods:
- **INFO: (This will only works for string type) If you want to use like a path, for example: `"C:\Users\User"`, you can't just type that in, it will give you an error, instead, you should use `@"C:\Users\User"`, this will allow you to use `\` or `/` in the string but, if you resist, you can use `"C:\\Users\\User`, that will work as well.**

```csharp
using System;
using System.Threading.Tasks;
using Utility_LibraryHelper;

class Program
{
    static async Task Main(string[] args)
    {
        // HTTP Request Example
        await util.HttpReq("https://jsonplaceholder.typicode.com/posts/1");

        // .NET Version Identifier Example
        int version;
        util.DotNetVersionIdentifier(out version);
        Console.WriteLine($".NET Version: {version}");

        // Log Info Example
        util.LogInfo("This is a log message.", "log.txt");

        // Download File Example
        await util.DownloadFile("https://example.com/sample.txt", "sample.txt");

        // Move File Example
        util.MoveFile("source.txt", "destination.txt");

        // Create Directory Example
        util.CreateDirectory("NewDirectory");

        // Directory Exists Example
        bool directoryExists = util.DirectoryExists("NewDirectory");
        Console.WriteLine($"Directory Exists: {directoryExists}");

        // File Exists Example
        bool fileExists = util.FileExists("sample.txt");
        Console.WriteLine($"File Exists: {fileExists}");

        // Read File Example
        string fileContent = util.ReadFile("sample.txt");
        Console.WriteLine($"File Content: {fileContent}");

        // Write File Example
        util.WriteFile("output.txt", "This is the content to write.");

        // Append to File Example
        util.AppendToFile("output.txt", " This content will be appended.");

        // Delete Directory Example
        util.DeleteDirectory("NewDirectory");

        // Copy Directory Example
        util.CopyDirectory("sourceDirectory", "destinationDirectory");

        // Get Files in Directory Example
        string[] files = util.GetFilesInDirectory("sourceDirectory");
        Console.WriteLine($"Files in Directory: {string.Join(", ", files)}");

        // Get Directories in Directory Example
        string[] directories = util.GetDirectoriesInDirectory("sourceDirectory");
        Console.WriteLine($"Directories in Directory: {string.Join(", ", directories)}");

        // Get File Name Without Extension Example
        string fileNameWithoutExtension = util.GetFileNameWithoutExtension("example.txt");
        Console.WriteLine($"File Name Without Extension: {fileNameWithoutExtension}");

        // Get File Extension Example
        string fileExtension = util.GetFileExtension("example.txt");
        Console.WriteLine($"File Extension: {fileExtension}");

        // Move Directory Example
        util.MoveDirectory("sourceDirectory", "destinationDirectory");

        // Delete File If Exists Example
        util.DeleteFileIfExists("fileToDelete.txt");

        // Get File Name Example
        string fileName = util.GetFileName("example.txt");
        Console.WriteLine($"File Name: {fileName}");

        // Get Directory Name Example
        string directoryName = util.GetDirectoryName("C:\\Directory\\Subdirectory\\");
        Console.WriteLine($"Directory Name: {directoryName}");

        // Get File Size Example
        long fileSize = util.GetFileSize("example.txt");
        Console.WriteLine($"File Size: {fileSize}");

        // Compress File Example
        await util.CompressFile("sample.txt", "compressedSample.gz");

        // Decompress File Example
        await util.DecompressFile("compressedSample.gz", "decompressedSample.txt");

        // Encrypt File Example
        await util.EncryptFile("sample.txt", "encryptedSample.dat");

        // Decrypt File Example
        string encryptedFilePath = "path/to/encrypted/file";
        string decryptedFilePath = "path/to/save/decrypted/file";
        string key = "your_secret_key"; // The same key used for encryption

        await Util.DecryptFile(encryptedFilePath, decryptedFilePath, key, showVerbose: true);

    }
}

```

## API Reference
# `util` Class Methods
- **There are over 26 different methods to use which is:**
- **INFO: All of these contain `ShowVerbose` as boolean which can be used to print additional information following the methods you are using, if you wanted to view/see the additional information, you can just change from the default (which is `false` to be exact) to true by typing `ShowVerbose: true`, if you don't want it enabled, you can just leave it empty**
```csharp
0. util.HttpReq(string httpRequestURL, CancellationToken cancellationToken = default, bool showVerbose = false);
// This method sends an HTTP GET request to the specified URL ("https://jsonplaceholder.typicode.com/posts/1") and prints the response content to the console.
```

```csharp
1. util.DotNetVersionIdentifier(out int outputVersion, bool showVerbose = false);
// This method retrieves the current .NET runtime version and outputs it to the console.
```

```csharp
2. util.LogInfo(string loggingMessage, string filePath, bool showVerbose = false);
// This method logs a message ("This is a log message.") to a log file named "log.txt" along with a timestamp.
```

```csharp
3. util.DownloadFile(string URL, string destinationPath, bool showVerbose = false);
// This method downloads a file from the specified URL ("https://example.com/sample.txt") and saves it to the local file system with the name "sample.txt".
```

```csharp
4. util.MoveFile(string sourceFilePath, string destinationFilePath, bool showVerbose = false);
// This method moves a file from the source path ("source.txt") to the destination path ("destination.txt").
```

```csharp
5. util.CreateDirectory(string directoryPath, bool showVerbose = false);
// This method creates a new directory named "NewDirectory" in the current working directory.
```

```csharp
6. util.DirectoryExists(string directoryPath, bool showVerbose = false);
// This method checks if the directory "NewDirectory" exists and prints the result (true or false) to the console.
```

```csharp
7. util.FileExists(string filePath, bool showVerbose = false);
// This method checks if the file "sample.txt" exists and prints the result (true or false) to the console.
```

```csharp
8. util.ReadFile(string filePath, bool showVerbose = false);
// This method reads the contents of the file "sample.txt" and prints it to the console.
```

```csharp
9. util.WriteFile(string filePath, string content, bool showVerbose = false);
// This method writes the content "This is the content to write." to a new file named "output.txt".
```

```csharp
10. util.AppendToFile(string filePath, string content, bool showVerbose = false);
// This method appends the content " This content will be appended." to the existing file "output.txt".
```

```csharp
11 .util.DeleteDirectory(string directoryPath, bool showVerbose = false);
// This method deletes the directory "NewDirectory" and all its contents.
```

```csharp
12. util.CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath, bool showVerbose = false);
// This method recursively copies the contents of the directory "sourceDirectory" to "destinationDirectory".
```

```csharp
13. util.GetFilesInDirectory(string directoryPath, bool showVerbose = false)
// This method retrieves an array of file paths in the directory "sourceDirectory" and prints them to the console.
```

```csharp
14. util.GetDirectoriesInDirectory(string directoryPath, bool showVerbose = false)
// This method retrieves an array of directory paths in the directory "sourceDirectory" and prints them to the console.
```

```csharp
15. util.GetFileNameWithoutExtension(string filePath, bool showVerbose = false);
// This method retrieves the file name without the extension from the path "example.txt" and prints it to the console.
```

```csharp
16. util.GetFileExtension(string filePath, bool showVerbose = false);
// This method retrieves the file extension from the path "example.txt" and prints it to the console.
```

```csharp
17. util.MoveDirectory(string sourceDirectoryPath, string destinationDirectoryPath, bool showVerbose = false);
// This method moves the directory "sourceDirectory" to "destinationDirectory".
```

```csharp
18. util.DeleteFileIfExists(string filePath, bool showVerbose = false);
// This method deletes the file "fileToDelete.txt" if it exists.
```

```csharp
19. util.GetFileName(string filePath, bool showVerbose = false);
// This method retrieves the file name from the path "example.txt" and prints it to the console.
```

```csharp
20. util.GetDirectoryName(string directoryPath, bool showVerbose = false);
// This method retrieves the directory name from the path "C:\Directory\Subdirectory" and prints it to the console.
```

```csharp
21. util.GetFileSize(string filePath, bool showVerbose = false)
// This method retrieves the size of the file "example.txt" in bytes and prints it to the console.
```

```csharp
22. util.CompressFile(string filePath, string compressedFilePath, bool showVerbose = false);
// This method compresses the file "sample.txt" using GZip compression and saves the compressed file as "compressedSample.gz".
```

```csharp
23. util.DecompressFile(string compressedFilePath, string decompressedFilePath, bool showVerbose = false);
// This method decompresses the file "compressedSample.gz" and saves the decompressed content as "decompressedSample.txt".
```

```csharp
24. util.EncryptFile(string filePath, string encryptedFilePath, bool showVerbose = false);
// This method encrypts the file "sample.txt" using AES encryption and saves the encrypted content as "encryptedSample.dat".
```

```csharp
25. util.DecryptFilestring encryptedFilePath, string decryptedFilePath, string key, bool showVerbose = false);
```
## Dependencies used (if you wanted to know):
```csharp
 using System;
 using System.IO;
 using System.Net;
 using System.Net.Http;
 using System.Threading;
 using System.Threading.Tasks;
 using System.Security.Cryptography;
 using System.IO.Compression;
```


## License
This library is provided under the MIT License.
****
