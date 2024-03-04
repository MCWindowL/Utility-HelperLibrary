#pragma warning disable

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO.Compression;

namespace Utility_LibraryHelper
{
    public class util
    {
        public static async Task HttpReq(string httpRequestURL, CancellationToken cancellationToken = default, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"HTTP Request: {httpRequestURL}");
            }

            using HttpClient client = new();

            try
            {
                HttpResponseMessage response = await client.GetAsync(httpRequestURL, cancellationToken);

                // If response is successful
                if (response.IsSuccessStatusCode)
                {
                    string URLContent = await response.Content.ReadAsStringAsync(cancellationToken);
                    Console.WriteLine(URLContent);
                }
                else
                {
                    Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP request failed: {e.Message}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("HTTP request was cancelled.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        public static void DotNetVersionIdentifier(out int outputVersion, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine("Identifying .NET version.");
            }

            Version sv = Environment.Version;
            outputVersion = int.Parse($"{sv.Major}{sv.Minor}");
            if (showVerbose)
            {
                Console.WriteLine($".NET version has been written to: {outputVersion}");
            }
        }

        public static void LogInfo(string loggingMessage, string filePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Logging message: {loggingMessage}");
            }

            try
            {
                DateTime now = DateTime.Now;
                string formattedMessage = $"{now:yyyy-MM-dd HH:mm:ss} - {loggingMessage}";
                File.AppendAllText(filePath, formattedMessage + Environment.NewLine);
                if (showVerbose)
                {
                    Console.WriteLine($"Successfully appended text to: {filePath}");
                }
            }
            catch (Exception ex)
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Error while logging: {ex.Message}");
                }
            }
        }

        public static async Task DownloadFile(string URL, string destinationPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Downloading File from {URL} to {destinationPath}");
            }

            try
            {
                using (HttpClient httpClient = new())
                using (HttpResponseMessage response = await httpClient.GetAsync(URL))
                using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                {
                    using Stream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    await contentStream.CopyToAsync(fileStream);
                }

                if (showVerbose)
                {
                    Console.WriteLine($"File downloaded at: {destinationPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
            }
        }


        public static void MoveFile(string sourceFilePath, string destinationFilePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Moving File {sourceFilePath} to {destinationFilePath}");
            }

            try
            {
                File.Move(sourceFilePath, destinationFilePath);

                if (showVerbose)
                {
                    Console.WriteLine($"File moved from {sourceFilePath} to {destinationFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving file: {ex.Message}");
            }
        }

        public static void CreateDirectory(string directoryPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Creating Folder at: {directoryPath}");
            }

            try
            {
                Directory.CreateDirectory(directoryPath);

                if (showVerbose)
                {
                    Console.WriteLine($"Directory created at: {directoryPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
        }

        public static bool DirectoryExists(string directoryPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Checking if directory exists: {directoryPath}");
            }

            return Directory.Exists(directoryPath);
        }

        public static bool FileExists(string filePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Checking if file exists: {filePath}");
            }

            return File.Exists(filePath);
        }

        public static string ReadFile(string filePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Reading file: {filePath}");
            }

            return File.ReadAllText(filePath);
        }

        public static void WriteFile(string filePath, string content, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Writing content to file: {filePath}");
            }

            File.WriteAllText(filePath, content);

            if (showVerbose)
            {
                Console.WriteLine($"Successfully wrote content to: {filePath}");
            }
        }

        public static void AppendToFile(string filePath, string content, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Appending content to file: {filePath}");
            }

            File.AppendAllText(filePath, content);

            if (showVerbose)
            {
                Console.WriteLine($"Successfully appended content to: {filePath}");
            }
        }

        public static void DeleteDirectory(string directoryPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Deleting directory: {directoryPath}");
            }

            try
            {
                Directory.Delete(directoryPath, true);

                if (showVerbose)
                {
                    Console.WriteLine($"Deleted directory: {directoryPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting directory: {ex.Message}");
            }
        }

        public static void CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Copying directory from {sourceDirectoryPath} to {destinationDirectoryPath}");
            }

            try
            {
                Directory.CreateDirectory(destinationDirectoryPath);
                foreach (string filePath in Directory.GetFiles(sourceDirectoryPath))
                {
                    string fileName = Path.GetFileName(filePath);
                    string destFilePath = Path.Combine(destinationDirectoryPath, fileName);
                    File.Copy(filePath, destFilePath);
                }
                foreach (string subDirectoryPath in Directory.GetDirectories(sourceDirectoryPath))
                {
                    string subDirectoryName = Path.GetFileName(subDirectoryPath);
                    string destSubDirectoryPath = Path.Combine(destinationDirectoryPath, subDirectoryName);
                    CopyDirectory(subDirectoryPath, destSubDirectoryPath, showVerbose);
                }

                if (showVerbose)
                {
                    Console.WriteLine($"Successfully copied directory from {sourceDirectoryPath} to {destinationDirectoryPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying directory: {ex.Message}");
            }
        }

        public static string[] GetFilesInDirectory(string directoryPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Getting files in directory: {directoryPath}");
            }

            string[] files = Directory.GetFiles(directoryPath);

            if (showVerbose)
            {
                Console.WriteLine($"Found {files.Length} files in directory: {directoryPath}");
            }

            return files;
        }

        public static string[] GetDirectoriesInDirectory(string directoryPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Getting directories in directory: {directoryPath}");
            }

            return Directory.GetDirectories(directoryPath);
        }

        public static string GetFileNameWithoutExtension(string filePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Getting file name without extension: {filePath}");
            }

            return Path.GetFileNameWithoutExtension(filePath);
        }

        public static string GetFileExtension(string filePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Getting file extension: {filePath}");
            }

            return Path.GetExtension(filePath);
        }

        public static void MoveDirectory(string sourceDirectoryPath, string destinationDirectoryPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Moving directory from {sourceDirectoryPath} to {destinationDirectoryPath}");
            }

            try
            {
                Directory.Move(sourceDirectoryPath, destinationDirectoryPath);

                if (showVerbose)
                {
                    Console.WriteLine($"Successfully moved directory from {sourceDirectoryPath} to {destinationDirectoryPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving directory: {ex.Message}");
            }
        }

        public static void DeleteFileIfExists(string filePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Deleting file if exists: {filePath}");
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);

                if (showVerbose)
                {
                    Console.WriteLine($"Deleted file: {filePath}");
                }
            }
            else if (showVerbose)
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }

        public static string GetFileName(string filePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Getting file name: {filePath}");
            }

            return Path.GetFileName(filePath);
        }

        public static string? GetDirectoryName(string directoryPath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Getting directory name: {directoryPath}");
            }

            if (directoryPath == null)
            {
                // Optionally handle null input here, or return a default value
                // For example, you might throw an ArgumentNullException
                throw new ArgumentNullException(nameof(directoryPath), "Directory path cannot be null.");
            }

            return System.IO.Path.GetDirectoryName(directoryPath);
        }

        public static long GetFileSize(string filePath, bool showVerbose = false)
        {
            if (showVerbose)
            {
                Console.WriteLine($"Getting file size for {filePath}");
            }

            if (File.Exists(filePath))
            {
                return new FileInfo(filePath).Length;
            }
            else
            {
                throw new FileNotFoundException($"File '{filePath}' not found.");
            }
        }

        public static async Task<string> CompressFile(string filePath, string compressedFilePath, bool showVerbose = false)
        {
            try
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Compressing file: {filePath}");
                }

                using (FileStream fsInput = new(filePath, FileMode.Open, FileAccess.Read))
                using (FileStream fsCompressed = new(compressedFilePath, FileMode.Create, FileAccess.Write))
                using (GZipStream gzipStream = new(fsCompressed, CompressionMode.Compress))
                {
                    await fsInput.CopyToAsync(gzipStream);
                }

                if (showVerbose)
                {
                    Console.WriteLine($"File compressed successfully: {compressedFilePath}");
                }

                return compressedFilePath;
            }
            catch (Exception ex)
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Error compressing file: {ex.Message}");
                }

                throw;
            }
        }

        public static async Task<string> DecompressFile(string compressedFilePath, string decompressedFilePath, bool showVerbose = false)
        {
            try
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Decompressing file: {compressedFilePath}");
                }

                using (FileStream fsInput = new(compressedFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream fsDecompressed = new(decompressedFilePath, FileMode.Create, FileAccess.Write))
                using (GZipStream gzipStream = new(fsInput, CompressionMode.Decompress))
                {
                    await gzipStream.CopyToAsync(fsDecompressed);
                }

                if (showVerbose)
                {
                    Console.WriteLine($"File decompressed successfully: {decompressedFilePath}");
                }

                return decompressedFilePath;
            }
            catch (Exception ex)
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Error decompressing file: {ex.Message}");
                }

                throw;
            }
        }

        public static async Task<string> EncryptFile(string filePath, string encryptedFilePath, bool showVerbose = false)
        {
            try
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Encrypting file: {filePath}");
                }

                string key = GenerateRandomKey(); // Generate a random key for encryption

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Convert.FromBase64String(key);
                    aesAlg.GenerateIV();

                    using FileStream fsInput = new(filePath, FileMode.Open, FileAccess.Read);
                    using FileStream fsEncrypted = new(encryptedFilePath, FileMode.Create, FileAccess.Write);
                    using ICryptoTransform encryptor = aesAlg.CreateEncryptor();
                    using CryptoStream csEncrypt = new(fsEncrypted, encryptor, CryptoStreamMode.Write);
                    // Write the IV to the beginning of the file
                    fsEncrypted.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    // Encrypt the file content
                    await fsInput.CopyToAsync(csEncrypt);
                }

                if (showVerbose)
                {
                    Console.WriteLine($"File encrypted successfully: {encryptedFilePath}");
                }

                return encryptedFilePath;
            }
            catch (Exception ex)
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Error encrypting file: {ex.Message}");
                }

                throw;
            }
        }

        // Helper method to generate a random key
        private static string GenerateRandomKey()
        {
            using Aes aes = Aes.Create();
            aes.GenerateKey();
            return Convert.ToBase64String(aes.Key);
        }
        public static async Task<string> DecryptFile(string encryptedFilePath, string decryptedFilePath, string key, bool showVerbose = false)
        {
            try
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Decrypting file: {encryptedFilePath}");
                }

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Convert.FromBase64String(key);

                    // Read the IV from the beginning of the encrypted file
                    byte[] iv = new byte[aesAlg.IV.Length];
                    using (FileStream fsEncrypted = new(encryptedFilePath, FileMode.Open, FileAccess.Read))
                    {
                        fsEncrypted.Read(iv, 0, iv.Length);
                    }

                    aesAlg.IV = iv;

                    using (FileStream fsEncrypted = new(encryptedFilePath, FileMode.Open, FileAccess.Read))
                    using (FileStream fsDecrypted = new(decryptedFilePath, FileMode.Create, FileAccess.Write))
                    using (ICryptoTransform decryptor = aesAlg.CreateDecryptor())
                    using (CryptoStream csDecrypt = new(fsDecrypted, decryptor, CryptoStreamMode.Write))
                    {
                        // Start reading after the IV
                        fsEncrypted.Seek(aesAlg.IV.Length, SeekOrigin.Begin);
                        await fsEncrypted.CopyToAsync(csDecrypt);
                    }
                }

                if (showVerbose)
                {
                    Console.WriteLine($"File decrypted successfully: {decryptedFilePath}");
                }

                return decryptedFilePath;
            }
            catch (Exception ex)
            {
                if (showVerbose)
                {
                    Console.WriteLine($"Error decrypting file: {ex.Message}");
                }

                throw;
            }
        }

    }
}
