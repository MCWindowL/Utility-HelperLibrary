using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Utility_HelperLibrary
{
    public class util // Handles util. commands
    {
        public static async Task HttpReq(string httpRequestURL, CancellationToken cancellationToken = default)
        {
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

        public static void DotNetVersionIdentifier(out int outputVersion)
        {
            Version dvr = Environment.Version;
            outputVersion = int.Parse($"{dvr.Major}{dvr.Minor}");
        }

        public static void LogInfo(string loggingMessage, string filePath)
        {
            try
            {
                DateTime now = DateTime.Now;
                string formattedMessage = $"{now:yyyy-MM-dd HH:mm:ss} - {loggingMessage}";
                File.AppendAllText(filePath, formattedMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while logging: {ex.Message}");
            }
        }

        public static void DownloadFile(string URL, string DestinationPath)
        {
            WebClient client = new();

            try
            {
                client.DownloadFile(URL, DestinationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERR.CODE: {ex.Message}");
            }
            finally
            {
                client.Dispose();
            }
        }

        public static void MoveFile(string sourceFilePath, string destinationFilePath)
        {
            File.Move(sourceFilePath, destinationFilePath);
        }

        public static void CreateDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
        }

        public static bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static void WriteFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        public static void AppendToFile(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        public static void DeleteDirectory(string directoryPath)
        {
            Directory.Delete(directoryPath, true);
        }

        public static void CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath)
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
                CopyDirectory(subDirectoryPath, destSubDirectoryPath);
            }
        }

        public static string[] GetFilesInDirectory(string directoryPath)
        {
            return Directory.GetFiles(directoryPath);
        }

        public static string[] GetDirectoriesInDirectory(string directoryPath)
        {
            return Directory.GetDirectories(directoryPath);
        }

        public static string GetFileNameWithoutExtension(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public static string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }

        public static void MoveDirectory(string sourceDirectoryPath, string destinationDirectoryPath)
        {
            Directory.Move(sourceDirectoryPath, destinationDirectoryPath);
        }

        public static void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public static string GetDirectoryName(string directoryPath)
        {
            return Path.GetDirectoryName(directoryPath);
        }

        public static long GetFileSize(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new FileInfo(filePath).Length;
            }
            else
            {
                throw new FileNotFoundException($"File '{filePath}' not found.");
            }
        }
    }
}
