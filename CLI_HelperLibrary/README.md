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

    ```csharp
    <Reference Include="UtilHelper">
    <HintPath>(your project path)\UtilityHelperLibrary\bin\Debug\net8.0\CLI_HelperLibrary.dll</HintPath>
    </Reference>
    ```
  4. Then add the library using: 
  ```csharp 
  using UtilHelper;
  ```
  5. That's it! Now you can use `util.(some command)` to run based on your preferences.


## 2. Examples

Here are some examples demonstrating how to use the Utility Helper Library methods:

```csharp
using Utility_HelperLibrary;

class Program
{
    static async Task Main(string[] args)
    {
        // Example of sending an HTTP request
        await util.HttpReq("https://example.com/api/data");

        // Example of downloading a file
        util.DownloadFile("https://example.com/file.txt", "downloaded_file.txt");

        // Example of moving a file
        util.MoveFile("source_file.txt", "destination_folder/source_file.txt");

        // Example of creating a directory
        util.CreateDirectory("new_directory");

        // Example of checking if a directory exists
        bool directoryExists = util.DirectoryExists("existing_directory");

        // Example of checking if a file exists
        bool fileExists = util.FileExists("existing_file.txt");

        // Example of logging
        util.LogInfo("Log message", "log_file.txt");
    }
}
```

## API Reference
# `Util` Class Methods
```csharp
1. HttpReq(string httpRequestURL, CancellationToken cancellationToken = default); 
// This will sends an HTTP request asynchronously.
```
```csharp
2. DotNetVersionIdentifier(out int outputVersion);
// Identifies the version of the .NET runtime environment.
```
```csharp
3. LogInfo(string loggingMessage, string filePath);
// Logs a message to a file.
```
```csharp
4. DownloadFile(string URL, string DestinationPath);
// Downloads a file from a URL.
```
```csharp
5. MoveFile(string sourceFilePath, string destinationFilePath);
// Moves a file to a new location.
```
```csharp
6. CreateDirectory(string directoryPath);
// Creates a new directory.
```
```csharp
DirectoryExists(string directoryPath);
// Checks if a directory exists.
```
```csharp
FileExists(string filePath);
// Checks if a file exists.
```
```csharp
ReadFile(string filePath);
// Reads the contents of a file.
```
```csharp
WriteFile(string filePath, string content);
// Writes content to a file.
```
```csharp
AppendToFile(string filePath, string content);
// Appends content to a file.
```
```csharp
DeleteDirectory(string directoryPath);
// Deletes a directory and its contents.
```
```csharp
CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath);
// Copies a directory and its contents to a new location.
```
```csharp
GetFilesInDirectory(string directoryPath);
// Gets a list of files in a directory.
```
```csharp
GetDirectoriesInDirectory(string directoryPath);
// Gets a list of directories in a directory.
```
```csharp
GetFileNameWithoutExtension(string filePath);
// Gets the file name without the extension.
```
```csharp
GetFileExtension(string filePath);
// Gets the file extension.
```
```csharp
MoveDirectory(string sourceDirectoryPath, string destinationDirectoryPath);
// Moves a directory to a new location.
```
```csharp
DeleteFileIfExists(string filePath);
// Deletes a file if it exists.
```
```csharp
GetFileName(string filePath);
// Gets the file name from a file path.
```
```csharp
GetDirectoryName(string directoryPath);
// Gets the directory name from a directory path.
```
```csharp
GetFileSize(string filePath)
// Gets the size of a file.
```

## License
This library is provided under the MIT License.
****